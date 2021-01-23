    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, (this.Width / 2), (this.Height / 2), 135, 195);
        path.AddArc((this.Width / 2), 0, (this.Width / 2), (this.Height / 2), 210, 195);
        path.AddLine((this.Width / 2), this.Height, (this.Width / 2), this.Height);
        
        GraphicsPath path2 = new GraphicsPath();
        path2.AddRectangle(new Rectangle(new Point(0, 0), panel1.Size));
        
        path2.AddPath(path, false);
        
        e.Graphics.FillPath(Brushes.Black, path2);
    }
