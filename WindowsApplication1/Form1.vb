Public Class Form1
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim MyBitmap As New Bitmap(PictureBox1.Image)
        Dim MyColor As Color
        Dim MyShadeOfGrey As Integer
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("\\Mac\Home\Desktop\test.txt", True)

        For x As Integer = 0 To MyBitmap.Size.Width - 1
            For y As Integer = 0 To MyBitmap.Size.Height - 1
                MyColor = MyBitmap.GetPixel(x, y)
                Dim R As Integer = MyColor.R
                Dim B As Integer = MyColor.B
                Dim G As Integer = MyColor.G
                If (R + G + B) > 300 Then
                    MyShadeOfGrey = 0
                    file.Write(1)
                Else
                    MyShadeOfGrey = 255
                    file.Write(0)
                End If
                MyColor = Color.FromArgb(MyShadeOfGrey, MyShadeOfGrey, MyShadeOfGrey)
                MyBitmap.SetPixel(x, y, MyColor)
            Next
        Next
        'Label1.Text = MyColor.Name
        PictureBox1.Image = MyBitmap
        PictureBox1.Update()
        file.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim file As String
        Dim counter As Integer = 8
        Dim tmpNumber As Integer = 0
        Dim output As System.IO.StreamWriter
        output = My.Computer.FileSystem.OpenTextFileWriter("\\Mac\Home\Desktop\testHex.txt", True)
        file = My.Computer.FileSystem.ReadAllText("\\Mac\Home\Desktop\test.txt")
        For Each c As Char In file
            counter -= 1
            If c = "1" Then
                tmpNumber += (2 ^ counter)
            End If
            'output.WriteLine("Tmp num is " + tmpNumber.ToString + "counter " + counter.ToString)
            If counter = 0 Then
                output.WriteLine(Hex(tmpNumber))
                tmpNumber = 0
                counter = 8
            End If
        Next
        output.Close()
    End Sub
End Class