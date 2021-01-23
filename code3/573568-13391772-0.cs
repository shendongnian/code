    Point mousePoint;
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        mousePoint = e.Location;
    }
    
    private void button1_MouseMove(object sender, MouseEventArgs e)
    {
        mousePoint = new Point(button1.Location.X + e.Location.X, button1.Location.Y + e.Location.Y);
    }
