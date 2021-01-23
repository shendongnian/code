            private unsafe Bitmap ToBitmap(double[,] rawImage)
            {
                int width = rawImage.GetLength(1);
                int height = rawImage.GetLength(0);
    
                Bitmap Image = new Bitmap(width, height);
                BitmapData bitmapData = Image.LockBits(
                    new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadWrite,
                    PixelFormat.Format32bppArgb
                );
                ColorARGB* startingPosition = (ColorARGB*) bitmapData.Scan0;
    
    
                for (int i = 0; i < height; i++)
                    for (int j = 0; j < width; j++)
                    {
                        double color = rawImage[j, i];
                        byte rgb = (byte)(color * 255);
    
                        ColorARGB* position = startingPosition + j + i * width;
                        position->A = 255;
                        position->R = rgb;
                        position->G = rgb;
                        position->B = rgb;
                    }
    
                Image.UnlockBits(bitmapData);
                return Image;
            }
    
            public struct ColorARGB
            {
                public byte B;
                public byte G;
                public byte R;
                public byte A;
    
                public ColorARGB(Color color)
                {
                    A = color.A;
                    R = color.R;
                    G = color.G;
                    B = color.B;
                }
    
                public ColorARGB(byte a, byte r, byte g, byte b)
                {
                    A = a;
                    R = r;
                    G = g;
                    B = b;
                }
    
                public Color ToColor()
                {
                    return Color.FromArgb(A, R, G, B);
                }
            }
