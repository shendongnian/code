    protected override void OnPaint(PaintEventArgs e)
    {
        GraphicsPath path = new GraphicsPath();
        SolidBrush br = new SolidBrush(Color.FromArgb(1, 0, 0));
        path.AddString("LLOOOOLL", Font.FontFamily, (int)Font.Style, Font.SizeInPoints, 
                       new Point(55, 55), StringFormat.GenericDefault);
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        e.Graphics.FillPath(br, path);
    }
