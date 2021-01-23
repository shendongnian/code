    operationsTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    { 
        operationsTimer.Enabled = false;
        //add item to collection code
        x++;
        if(x<100)
            operationsTimer.Enabled = true;
    }
