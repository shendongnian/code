    public void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            lock (StaticHelper.StaticBitmap)
            {
                using (Bitmap b = (Bitmap)eventArgs.Frame)
                {
                    StaticHelper.StaticBitmap = (Bitmap)b.Clone();
                }
            }
        }
    private void timer1_Tick(object sender, EventArgs e)
        {
            lock (StaticHelper.StaticBitmap)
            {
                pictureBox1.Image = (Bitmap)StaticHelper.StaticBitmap.Clone();
            }
        }
