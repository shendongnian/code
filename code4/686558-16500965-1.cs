    //the images are loaded in Bitmap image1, image2;
    for (int x = 0; x < image1.Width; x++)
    {
        for (int y = 0; y < image1.Height; y++)
        {
            if (image1.GetPixel(x, y) != image2.GetPixel(x, y))
            {
                posX = x; posY = y; //position of the pixel that is different
            }
        }
    }
