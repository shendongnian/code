            System.Drawing.Bitmap b0 = LoadBitmap();
            double scale = 203/96;
            int width = (int)(b0.Width * scale);
            int height = (int)(b0.Height * scale);
            System.Drawing.Bitmap bmpScaled = new System.Drawing.Bitmap(b0,width, height);
