        List<byte> bytes = new List<byte>(); // this list should be filled with values
        int width = 100;
        int height = 100;
        int bpp = 24;
        
        Bitmap bmp = new Bitmap(width, height);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {   
                int i = ((y * width) + x) * (bpp / 8);
                if(bpp == 24) // in this case you have 3 color values (red, green, blue)
                {
                     // first byte will be red, because you are writing it as first value
                     byte r = bytes[i]; 
                     byte g = bytes[i + 1]; 
                     byte b = bytes[i + 2]; 
                     Color color = Color.FromArgb(r, g, b);
                     bmp.SetPixel(x, y, color); 
                }
            }
        }
