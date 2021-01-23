    public void Form_Background(object sender, PaintEventArgs e)
        {
            Color c1 = Color.FromArgb(255, 252, 254, 255);
            Color c2 = Color.FromArgb(255, 247, 251, 253);
            Color c3 = Color.FromArgb(255, 228, 239, 247);
            Color c4 = Color.FromArgb(255, 217, 228, 238);
            Color c5 = Color.FromArgb(255, 200, 212, 217);
            Color c6 = Color.FromArgb(255, 177, 198, 215);
            Color c7 = Color.FromArgb(255, 166, 186, 208);
            // Changed: c1 / c7 as start colors, and at 90 degrees.  Removed later transform.
            LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle, c1, c7, 90, true);
            ColorBlend cb = new ColorBlend();
            cb.Positions = new[] { 0, (float)0.146, (float)0.317, (float)0.439, (float)0.585, (float)0.797, 1 };
            cb.Colors = new[] { c1, c2, c3, c4, c5, c6, c7 };
            br.InterpolationColors = cb;
            // removed rotate call
            // paint
            e.Graphics.FillRectangle(br, this.ClientRectangle);
        }
