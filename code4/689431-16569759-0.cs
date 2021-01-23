            Point upperLeftSouce = new Point(266, 400);
            Size blockRegionSize = new Size(385, 351);
            Bitmap bmp = new Bitmap(blockRegionSize.Width, blockRegionSize.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(upperLeftSouce, new Point(0, 0), bmp.Size);
            }
            for (int y = 0; y < bmp.Height; y += 40)
            {
                for (int x = 0; x < bmp.Width; x += 40)
                {
                    // ... code ..
                }
            }
