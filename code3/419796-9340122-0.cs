            Bitmap img = (Bitmap)Image.FromFile(@"C:\...");
            Color[,] pixels = new Color[img.Width, img.Height];
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    pixels[x, y] = img.GetPixel(x, y);
                }
            }
