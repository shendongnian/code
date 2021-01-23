    Bitmap originalImage;
    Bitmap adjustedImage;
    float brightness = 1.0f; // no change in brightness
    float contrast = 2.0f; // twice the contrast
    float gamma = 1.0f; // no change in gamma
    
    float adjustedBrightness = brightness - 1.0f;
    // create matrix that will brighten and contrast the image
    float[][] ptsArray ={
            new float[] {contrast, 0, 0, 0, 0}, // scale red
            new float[] {0, contrast, 0, 0, 0}, // scale green
            new float[] {0, 0, contrast, 0, 0}, // scale blue
            new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
            new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};
    
    ImageAttributes imageAttributes = new ImageAttributes();
    imageAttributes.ClearColorMatrix();
    imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
    imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
    Graphics g = Graphics.FromImage(adjustedImage);
    g.DrawImage(originalImage, new Rectangle(0,0,adjustedImage.Width,adjustedImage.Height)
        ,0,0,originalImage.Width,originalImage.Height,
        GraphicsUnit.Pixel, imageAttributes);
