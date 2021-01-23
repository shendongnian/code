    public static Bitmap ResizeBitmap(Bitmap sourceBM, int width, int height)
    {
        // Initialize Emgu Image object
        Image<Bgr, Byte> img = new Image<Bgr, Byte>(sourceBM); 
        
        // Resize using liniear interpolation
        img.Resize(width, height, INTER.CV_INTER_LINEAR);
    
        // Return .NET Bitmap object
        return img.ToBitmap();
    }
