     Private Function CloneImage(aImagePath As String) As Image
            ' create original image
            Dim originalImage As Image = New Bitmap(aImagePath)
    
            ' create an empty clone of the same size of original
            Dim clone As Bitmap = New Bitmap(originalImage.Width, originalImage.Height)
    
            ' get the object representing clone's currently empty drawing surface
            Dim g As Graphics = Graphics.FromImage(clone)
    
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed
    
            ' copy the original image onto this surface
            g.DrawImage(originalImage, 0, 0, originalImage.Width, originalImage.Height)
    
            ' free graphics and original image
            g.Dispose()
            originalImage.Dispose()
    
            Return CType(clone, Image)
        End Function
