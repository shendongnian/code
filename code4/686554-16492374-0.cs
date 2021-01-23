    timer.Tick += OnTick;
    timer.Interval = int1 * 60000;
    ...
    private void OnTick(object o, EventArgs e)
    {
       Console.Beep();     
    }
    
    
