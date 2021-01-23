    private void customBackgroundPainter(PaintEventArgs e, int linethickness = 2, Color linecolor = new Color(), int offsetborder = 6)
    {
        Rectangle rect = new Rectangle(offsetborder, offsetborder, this.ClientSize.Width - (offsetborder * 2), this.ClientSize.Height - (offsetborder * 2));
    
        Pen pen = new Pen(new Color());
        pen.Width = linethickness;
        if (linecolor != new Color())
        {
            pen.Color = linecolor;
        }
        else
        {
            pen.Color = Color.Black;
        }
         
        e.Graphics.DrawRectangle(pen, rect);
    }
