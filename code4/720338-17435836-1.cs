    byte[] getImageBytes(Image image)
    {
        Bitmap bmp = (Bitmap)image;
        byte[] bytes = new byte[(bmp.Width * bmp.Height) * 3]; // 3 for R+G+B
        
        for (int x = 0; x < bmp.Width; x++)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                Color pixel = bmp.GetPixel(x, y);
                bytes[x + y * bmp.Width + 0] = pixel.R;
                bytes[x + y * bmp.Width + 1] = pixel.G;
                bytes[x + y * bmp.Width + 2] = pixel.B;
            }
        }
        
        return bytes;
    }
