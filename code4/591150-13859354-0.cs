    public void DoStuff()
    {
        BackgroundWorker bw = new BackgroundWorker();
        bw.DoWork += (sender, args) =>
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap bmp = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.CopyFromScreen(
                    bounds.X,
                    bounds.Y,
                    0,
                    0,
                    bounds.Size,
                    CopyPixelOperation.SourceCopy
                );
            }
            args.Result = bmp;
        };
        bw.RunWorkerCompleted += (sender, e) =>
        {
            pictureBox1.Image = (Bitmap)e.Result;
        };
        bw.RunWorkerAsync();
    }
