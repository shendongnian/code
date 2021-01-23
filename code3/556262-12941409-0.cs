     private void timer1_Tick(object sender, EventArgs e)
    {
        this.DoubleBuffered = true;
        if (button1.Location.X > 10 && button1.Location.X < 550)
        {
            Point osp = new Point(button1.Location.X + 1, button1.Location.Y);                
            button1.Location = osp;
        }
        else
        {
            Point osp = new Point(11, button1.Location.Y);
            button1.Location = osp;
        }
        Application.DoEvents();  
     }
