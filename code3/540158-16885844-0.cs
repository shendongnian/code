    public void GetPrintArea(Panel pnl, Graphics gr)
    {
        // this should recurse...
        // just for demo so kept it simple
        foreach (var ctl in pnl.Controls)
        {
            // for every control type
            // come up with a way to Draw its
            // contents
            if (ctl is Label)
            {
                var lbl = (Label)ctl;
                gr.DrawString(
                    lbl.Text,
                    lbl.Font,
                    new SolidBrush(lbl.ForeColor),
                    lbl.Location.X,  // simple based on the position in the panel
                    lbl.Location.Y);
            }
            if (ctl is PictureBox)
            {
                var pic = (PictureBox)ctl;
                gr.DrawImageUnscaledAndClipped(
                    pic.Image,
                    new Rectangle(
                        pic.Location.X,
                        pic.Location.Y,
                        pic.Width,
                        pic.Height));
            }
        }
    }
    void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
    {
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality;
        e.Graphics.InterpolationMode =Drawing2D.InterpolationMode.HighQualityBilinear;
        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality;
        GetPrintArea(panel1, e.Graphics);
    }
