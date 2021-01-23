    protected virtual void OnMinimize(EventArgs e)
    {
        Rectangle r = this.RectangleToScreen(ClientRectangle);
        if (_lastSnapshot == null)
        {
            _lastSnapshot = new Bitmap(r.Width, r.Height);
        }
        using (Image windowImage = new Bitmap(r.Width, r.Height))
        using (Graphics windowGraphics = Graphics.FromImage(windowImage))
        using (Graphics tipGraphics = Graphics.FromImage(_lastSnapshot))
        {
            windowGraphics.CopyFromScreen(new Point(r.Left, r.Top), new Point(0, 0), new Size(r.Width, r.Height));
            windowGraphics.Flush();
            tipGraphics.DrawImage(windowImage, 0, 0, r.Width, r.Height);
        }
    }
