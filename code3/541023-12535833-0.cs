    System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
    
    
    t.Interval = 15000; // specify interval time as you want
    t.Tick += new EventHandler(timer_Tick);
    t.Start();
    
    void timer_Tick(object sender, EventArgs e)
    {
          //Call method
    }
