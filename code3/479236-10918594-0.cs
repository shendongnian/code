        while (true)
        {
            if (listBoxIndex != -1)
            {
                Rectangle rect = windowRects[listBoxIndex];
                Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    IntPtr hdc = g.GetHdc();
                    try
                    {
                        PrintWindow(windows[listBoxIndex], hdc, 0);
                    }
                    finally
                    {
                        g.ReleaseHdc(hdc);
                    }
                }
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
                pictureBox1.Image = bitmap;
            }
        }
