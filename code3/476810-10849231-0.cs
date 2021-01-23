    Bitmap buffer=new Bitmap(this.Width, this.Height); //make sure to resize the bitmap during the Form.Onresize event
    Form1()
    {
        InitializeComponent();
        Timer timer=new Timer();
        timer.Interval= 100;
        timer.Tick+=......
        timer.Start()
    }
    //the Timer tick event
    private void timer_tick(....
    {
        if (map.hasGraph)
        {
             using (Graphics g = Graphics.FromImage(buffer))
            {
                if (this.Index != null)
                    g.FillRectangle(Brush, Rectangle);
                if (OpponentIndex != null)
                    g.FillRectangle(OpponentBrush, OpponentRectangle);
            }
         panel1.BackgroundImage=buffer;
         }
    }
   
