     Private Sub PictureBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        Dim bits As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim context As Graphics = Graphics.FromImage(bits)
        '' Create picturebox background
        context.FillRectangle(New SolidBrush(PictureBox1.BackColor), _
                              0, 0, bits.Width, bits.Height)
        '' Try to reproduce zoomed image thumbnail
        Dim ratio As Double = 1.0
        Dim imageWidth As Integer = PictureBox1.Image.Width
        Dim imageHeight As Integer = PictureBox1.Image.Height
        If imageWidth > bits.Width Then
            ratio = bits.Width / imageWidth
            imageWidth = bits.Width
            imageHeight *= ratio
        End If
        If imageHeight > bits.Height Then
            ratio = bits.Height / imageHeight
            imageHeight = bits.Height
            imageWidth *= ratio
        End If
        context.DrawImage(PictureBox1.Image, _
                          New Rectangle((bits.Width - imageWidth) / 2, _
                                        (bits.Height - imageHeight) / 2, _
                                        imageWidth, imageHeight), _
                          New Rectangle(0, 0, PictureBox1.Image.Width, _
                                        PictureBox1.Image.Height), _
                          GraphicsUnit.Pixel)
        MsgBox(bits.GetPixel(e.X, e.Y).ToString)
    End Sub
