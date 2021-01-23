    public static Form Grayscale(Form tocover)
    {
        var frm = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                ControlBox = false,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.Manual,
                AutoScaleMode = AutoScaleMode.None,
                Location = tocover.PointToScreen(tocover.ClientRectangle.Location),
                Size = tocover.ClientSize
            };
        frm.Paint += (sender, args) =>
            {
                var bmp = GetFormImageWithoutBorders(tocover);
                bmp = ConvertToGrayscale(bmp);
                args.Graphics.DrawImage(bmp, args.ClipRectangle.Location);
            };
        frm.Show(tocover);
        return frm;
    }
    private static Bitmap ConvertToGrayscale(Bitmap source)
    {
        var bm = new Bitmap(source.Width, source.Height);
        for (int y = 0; y < bm.Height; y++)
        {
            for (int x = 0; x < bm.Width; x++)
            {
                Color c = source.GetPixel(x, y);
                var luma = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                bm.SetPixel(x, y, Color.FromArgb(luma, luma, luma));
            }
        }
        return bm;
    }
    private static Bitmap GetControlImage(Control ctl)
    {
        var bm = new Bitmap(ctl.Width, ctl.Height);
        ctl.DrawToBitmap(bm, new Rectangle(0, 0, ctl.Width, ctl.Height));
        return bm;
    }
    private static Bitmap GetFormImageWithoutBorders(Form frm)
    {
        // Get the form's whole image.
        using (Bitmap wholeForm = GetControlImage(frm))
        {
            // See how far the form's upper left corner is
            // from the upper left corner of its client area.
            Point origin = frm.PointToScreen(new Point(0, 0));
            int dx = origin.X - frm.Left;
            int dy = origin.Y - frm.Top;
            // Copy the client area into a new Bitmap.
            int wid = frm.ClientSize.Width;
            int hgt = frm.ClientSize.Height;
            var bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(wholeForm, 0, 0,
                    new Rectangle(dx, dy, wid, hgt),
                    GraphicsUnit.Pixel);
            }
            return bm;
        }
    }
