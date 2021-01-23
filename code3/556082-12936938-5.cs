    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
            e.DrawFocusRectangle();
            string url = data[e.Index].Substring(0, 4);
            Font f = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            SizeF size = e.Graphics.MeasureString(url, f);
            RectangleF urlRectF = new RectangleF(e.Bounds.X, e.Bounds.Y, size.Width, e.Bounds.Height);
            e.Graphics.DrawString(url, f, new SolidBrush(Color.Red), urlRectF);
            RectangleF restRectF = new RectangleF(e.Bounds.X + size.Width, e.Bounds.Y, e.Bounds.Width - size.Width, e.Bounds.Height);
            e.Graphics.DrawString(data[e.Index].Substring(3), f, new SolidBrush(Color.Red), restRectF);
    }
