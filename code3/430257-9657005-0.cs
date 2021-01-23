public static Bitmap ThresholdRGChroma(Bitmap original, Rectangle roi, double angle,
            double width, double satMin, double satMax)
        {
            Bitmap bimg = new Bitmap(original.Width, original.Height, PixelFormat.Format1bppIndexed);
            BitmapData imgData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, original.PixelFormat);
            BitmapData bimgData = bimg.LockBits(new Rectangle(0, 0, bimg.Width, bimg.Height), ImageLockMode.ReadWrite, bimg.PixelFormat);
            int pixelSize = 3;
            double r, g, sat, m;
            double satMin2 = satMin * satMin;
            double satMax2 = satMax * satMax;
            double cr = Math.Sin((2 * Math.PI * angle) / 360.0);
            double cg = Math.Cos((2 * Math.PI * angle) / 360.0);
            // Instead of (Math.Cos(2 * angleMax / 180.0) + 1) / 2.0 I'm using pre-calculated <0; 1> values.
            double w2 = width;
            unsafe
            {
                byte* R, G, B;
                byte* row;
                int RGBSum;
                for (int y = original.Height - 1; y >= 0; y--)
                {
                    row = (byte*)imgData.Scan0 + (y * imgData.Stride);
                    for (int x = original.Width - 1; x >= 0; x--)
                    {
                        B = &row[x * pixelSize];
                        G = &row[x * pixelSize + 1];
                        R = &row[x * pixelSize + 2];
                        RGBSum = *R + *G + *B;
                        if (RGBSum == 0)
                        {
                            SetIndexedPixel(x, y, bimgData, false);
                            continue;
                        }
                        r = (double)*R / RGBSum - _rgChromaOriginX;
                        g = (double)*G / RGBSum - _rgChromaOriginY;
                        m = cr * r + cg * g;
                        sat = r * r + g * g;
                        if (m > 0 && m * m > w2 * w2 * sat && sat >= satMin2 && sat <= satMax2)
                            SetIndexedPixel(x, y, bimgData, true);
                        else
                            SetIndexedPixel(x, y, bimgData, false);
                    }
                }
            }
            bimg.UnlockBits(bimgData);
            original.UnlockBits(imgData);
            return bimg;
        }
