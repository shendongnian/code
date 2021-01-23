    private void panel1_MouseClick(object sender, MouseEventArgs e)
    {
        Graphics g = panel1.CreateGraphics();
        g.DrawRectangle(new Pen(Brushes.Black),  
        new Rectangle(new Point(e.X, e.Y), new  
            Size(100, 100)));
    }
