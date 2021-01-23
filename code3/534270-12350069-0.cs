    private Timer myTimer = new Timer(1000); //using System.Timers, 1000 means 1000 msec = 1 sec interval
    
    public YourClassConstructor()
    {
        myTimer.Elapsed += TimerElapsed;
    }
    
    private void TimerElapsed(object sender, EventArgs e)
    {
        input = string.Empty;
        myTimer.Stop();
    }
    // this is your handler for KeyPress, which will be edited
    private void dataGridViewCustomers_KeyPress(object sender, KeyPressEventArgs e)
    {            
        if (myTimer.Enabled) myTimer.Stop(); // interval needs to be reset
        input += e.KeyChar.ToString();
        Find_Matches();
        myTimer.Start(); //in 1 sec, "input" will be cleared
    }
