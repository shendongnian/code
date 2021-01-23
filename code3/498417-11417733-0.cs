    for (var x = 0; x < sourceBitmap.Width; x++)
    {
        for (var y = 0; y < sourceBitmap.Height; y++)
        {
            var pixelColor = sourceBitmap.GetPixel(x, y);
    
            // copy all non-transparent pixels
            if (pixelColor.A != Byte.MaxValue) 
            {
                destinationBitmap.SetPixel(x, y, pixelColor);
            }
        }
    }
