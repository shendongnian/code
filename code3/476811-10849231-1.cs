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
                //You might need to clear the Bitmap first, and apply a backfround color or image
                //change color to whatever you want, or don't use this line at all, I don't know
                g.Clear(Color.AliceBlue);
                if (this.Index != null)
                    g.FillRectangle(Brush, Rectangle);
                if (OpponentIndex != null)
                    g.FillRectangle(OpponentBrush, OpponentRectangle);
            }
         panel1.BackgroundImage=buffer;
         }
    }
   
