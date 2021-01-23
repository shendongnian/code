    protected override void OnPaint(PaintEventArgs e)
    {
         base.OnPaint(e);
         e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
         e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
         e.Graphics.DrawImage(Properties.Resources.icon_32a, new RectangleF(0, 0, 512, 512), new RectangleF(0, 0, 32, 32), GraphicsUnit.Pixel);
    }
