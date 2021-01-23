        public double GetFValue(Image image)
        {
            Bitmap source = new Bitmap(image);
            int count = 0;
            double total = 0;
            double totalVariance = 0;
            double FM = 0;
            Bitmap bm = new Bitmap(source.Width, source.Height);
            Rectangle rect = new Rectangle(0, 0, source.Width, source.Height);
            //Bitmap targetRect = new Bitmap(rect.Width, rect.Height);
            //new
            ///*
            BitmapData bmd = source.LockBits(rect, ImageLockMode.ReadWrite, source.PixelFormat);
            int[] pixelData = new int[(rect.Height * rect.Width) -1];
            System.Runtime.InteropServices.Marshal.Copy(bmd.Scan0, pixelData, 0, pixelData.Length);
            for (int i = 0; i < pixelData.Length; i++)
            {
                count++;
                Color c = Color.FromArgb(pixelData[i]);
                int luma = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                pixelData[i] = Color.FromArgb(luma, luma, luma).ToArgb();
                total += luma;
                double avg = total / count;
                totalVariance += Math.Pow(luma - avg, 2);
                double stDV = Math.Sqrt(totalVariance / count);
                FM = Math.Round(stDV, 2);
            }
            source.UnlockBits(bmd);
            return FM;
         }
