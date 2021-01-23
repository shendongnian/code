    Timer timer = new Timer();
    timer.Interval = 3000;
    timer.Tick += new EventHandler(timer_Tick);
    //diplay the animated loader and start the timer 
    timer.Enabled = true;
    
--------------------------------
    void timer_Tick(object sender, EventArgs e)
    {
         //Elapsed 3000 milliseconds so you have to stop the timer
         timer.Enabled = false;
         //Now redirect the user
    } 
