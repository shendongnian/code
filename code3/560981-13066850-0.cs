    timer1.Tick += timer1_Tick;
    
    public void Top_MouseExit (object sender, EventArgs e)
    {
       PicTop.Visible = false; // or hide/disbale it some other way
       Timer1.Interval = 10000; //10 seconds
       Timer1.Start();
    }
    
    public void timer1_Tick(object sender, EventArgs e)
    {
        timer1.Stop();
        PicTop.Visible = true; //renable the top area
    }
