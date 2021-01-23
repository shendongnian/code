    private void CreatePanel()
    {
        Panel panel = new Panel();
        panel.Width = 600;
        panel.Height = 100;
        panel.Controls.Add(....);
        panel.Paint += (sender, e) =>
        {
            string color = "#FFE80000"; //*getting the hexa code*
            int argb = Int32.Parse(color.Replace("#", ""), NumberStyles.HexNumber);
            Color clr = Color.FromArgb(argb);
            Pen p = new Pen(clr);
            Rectangle r = new Rectangle(1, 1, 578, 38);
            e.Graphics.DrawRectangle(p, r);
        };
        Controls.Add(panel);
    }
