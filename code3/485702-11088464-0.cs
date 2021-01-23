    Dim img = Bitmap.FromFile("C:\Users\Public\Pictures\Sample Pictures\Desert.jpg")
    
    Using gfx = Graphics.FromImage(img)
        Dim r = New Rectangle(100, 150, 50, 50)
        gfx.SetClip(r, Drawing2D.CombineMode.Exclude)
        Using b = New SolidBrush(Color.FromArgb(128, 0, 0, 0))
            gfx.FillRectangle(b, New Rectangle(0, 0, img.Width, img.Height))
        End Using
        Me.PictureBox1.Image = img
    End Using
