        Bitmap copy_Screen()
        {
            try
            {
                var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                try
                {
                    gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                }
                catch (Exception) { }
                return bmpScreenshot;
            }
            catch (Exception) { }
            return new Bitmap(10, 10, PixelFormat.Format32bppArgb);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //Start Stop timer
            if (timer1.Enabled == false) { timer1.Enabled = true; } else { timer1.Enabled = false; }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //memory leak solve
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            Bitmap BM = copy_Screen();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = BM;
        }
