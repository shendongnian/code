    private Bitmap CloneImage(string aImagePath) {  
        // create original image
        Image originalImage = new Bitmap(aImagePath);
    
        // create an empty clone of the same size of original
        Bitmap clone = new Bitmap(originalImage.Width, originalImage.Height);
    
        // get the object representing clone's currently empty drawing surface
        Graphics g = Graphics.FromImage(clone);
    
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
    
        // copy the original image onto this surface
        g.DrawImage(originalImage, 0, 0, originalImage.Width, originalImage.Height);
    
        // free graphics and original image
        g.Dispose();
        originalImage.Dispose();
    
        return clone;
        }
