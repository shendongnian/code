    private void picBox_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Point p = ConvertFromChildToForm(e.X, e.Y, picBox);
            iOldX = p.X;
            iOldY = p.Y;
            iClickX = e.X;
            iClickY = e.Y;
            clicked = true;
        }
    }
    
    private void picBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (clicked)
        {
            Point p = new Point(); // New Coordinate
            p.X =  e.X + picBox.Left;
            p.Y =  e.Y + picBox.Top;
            picBox.Left = p.X - iClickX;
            picBox.Top = p.Y - iClickY;
        }
    }
    
    private void picBox_MouseUp(object sender, MouseEventArgs e)
    {
        clicked = false;   
    }
