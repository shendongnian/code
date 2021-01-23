	// Don't need this: Image image1 = Image.FromFile(@"C:\1.jpg");
    Bitmap bitmap = new Bitmap(@"C:\1.jpg");
    // Save the image in JPEG format.
    bitmap.Save(@"C:\test.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
    int x, y;
    // Loop through the images pixels to reset color. 
    for (x = 0; x < bitmap.Width; x++)
    {
        for (y = 0; y < bitmap.Height; y++)
        {
            Color pixelColor = bitmap.GetPixel(x, y);
            Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
            bitmap.SetPixel(x, y, newColor);
        }
    }
