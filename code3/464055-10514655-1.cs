    void c_Paint(object sender, PaintEventArgs e)
    {
        Control c = sender as Control;
        if (c != null)
        {
            string text = c.Tag.ToString();
            e.Graphics.SmoothingMode = 
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            RectangleF rect = new RectangleF(
                new PointF(19, 5), 
                e.Graphics.DrawString(text, this.Font, Brushes.Black, new PointF(19, 5));
        }
    }
