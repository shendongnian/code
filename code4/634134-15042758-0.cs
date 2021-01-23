    public class HtmlPoweredLabel : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            string html = string.Format(System.Globalization.CultureInfo.InvariantCulture,
            "<div style=\"font-family:{0}; font-size:{1}pt;\">{2}</div>",
            this.Font.FontFamily.Name,
            this.Font.SizeInPoints,
            this.Text);
            var topLeftCorner = new System.Drawing.PointF(0, 0);
            var size = this.Size;
            HtmlRenderer.HtmlRender.Render(e.Graphics, html, topLeftCorner, size);
            base.OnPaint(e);
        }
    }
