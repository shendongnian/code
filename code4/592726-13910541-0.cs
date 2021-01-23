    using System.Drawing;
    using System.Drawing.Imaging;
    // Open your two pictures as Bitmaps
    Bitmap im1 = (Bitmap)Bitmap.FromFile("file1.bmp");
    Bitmap im2 = (Bitmap)Bitmap.FromFile("file2.bmp");
    // Assuming they're the same size, loop through all the pixels
    for (int y = 0; y < im1.Height; y++)
    {
        for (int x = 0; x < im1.Width; x++)
        {
            // Get the color of the current pixel in each bitmap
            Color color1 = im1.GetPixel(x, y);
            Color color2 = im2.GetPixel(x, y);
            // Check if they're the same
            if (color1 != color2)
            {
                // If not, generate a color...
                Color myRed = Color.FromArgb(255, 0, 0);
                // .. and set the pixel in one of the bitmaps
                im1.SetPixel(x, y, myRed);
            }
        }
    }
    // Save the updated bitmap to a new file
    im1.Save("newfile.bmp", ImageFormat.Bmp);
