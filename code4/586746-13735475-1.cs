    public void Form_Background(object sender, PaintEventArgs e)
    {
        Rectangle r = this.ClientRectangle;
    
        if (r.Width > 0 && r.Height > 0) {
            Color c1 = Color.FromArgb(252, 254, 255);
            Color c2 = Color.FromArgb(247, 251, 253);
            Color c3 = Color.FromArgb(228, 239, 247);
            Color c4 = Color.FromArgb(217, 228, 238);
            Color c5 = Color.FromArgb(200, 212, 217);
            Color c6 = Color.FromArgb(177, 198, 215);
            Color c7 = Color.FromArgb(166, 186, 208);
    
            LinearGradientBrush br = new LinearGradientBrush(r, c1, c7, 90, true);
            ColorBlend cb = new ColorBlend();
            cb.Positions = new[] { 0, (float)0.146, (float)0.317, _
                                   (float)0.439, (float)0.585, _
                                   (float)0.797, 1 };
            cb.Colors = new[] { c1, c2, c3, c4, c5, c6, c7 };
            br.InterpolationColors = cb;
    
    
            // paint
            e.Graphics.FillRectangle(br, r);
        }
    }
