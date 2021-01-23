    void MyTimer_Tick(object sender, EventArgs e)
    {
        if(value)
        {
            //this stop the timer because dueTime is -1
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            MyFunction();
            //this start the timer
            _timer.Change(Convert.ToInt64(this.Interval.TotalSeconds), Convert.ToInt64(this.Interval.TotalSeconds));
        }
    }
