    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            Point p = ConvertFromChildToForm(e.X, e.Y, button1);
            iOldX = p.X;
            iOldY = p.Y;
            iClickX = e.X;
            iClickY = e.Y;
            clicked = true;
        }
    
    }
    
    private void button1_MouseMove(object sender, MouseEventArgs e)
    {
        if (clicked)
        {
            Point p = new Point();//in form coordinates
            p.X =  e.X + button1.Left;
            p.Y =  e.Y + button1.Top;
            button1.Left = p.X - iClickX;
            button1.Top = p.Y - iClickY;
    
        }
    
    }
    
    private void button1_MouseUp(object sender, MouseEventArgs e)
    {
        clicked = false;   
    }
