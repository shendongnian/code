    private void lstColor_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
    {
        var g = Graphics.FromHwnd(lstColor.Handle);
        var sf = new StringFormat(StringFormat.GenericTypographic);
        var size = g.MeasureString(data[e.Index], oFont, 500, sf);
        var width = size.Width + 16;
    
        e.DrawBackground();
        e.DrawFocusRectangle();
        e.Graphics.DrawString(data[e.Index], oFont, new SolidBrush(color[e.Index]), e.Bounds.X, e.Bounds.Y);
        e.Graphics.DrawString(data[data.Length - 1 - e.Index], oFont, new SolidBrush(color[color.Length - 1 - e.Index]), width, e.Bounds.Y);
    }
