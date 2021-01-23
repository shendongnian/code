    //Somewhere in a load event...
    timerDown.Tick += new EventHandler(timer_LiftDown);
    timerDown.Interval = 10;
    timerDown.Enabled = true;
    //More code...
    if (floorNo == 2)
    {
        timerDown.Start();
    }
    //More code...
    void timer_LiftDown(object sender, EventArgs e)
    {
        rectangle1.Location = new Point(192, rectangle1.Location.Y + 2);
        if (rectangle1.Location.Y >= 196)
        {
            timerDown.Stop();
        }
    }
