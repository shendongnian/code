    Timer timer = new Timer();
    
    private void Form1_Load(object sender, EventArgs e)
    {
        /* ... Some code ... */
    
        //regester the event handler here, and only do it once.
        timer.Tick += (sender, e) => timer_Tick(sender, e, Current_sharp.sharp);
    
        Watch().Start();
    }
    
    public Timer Watch()
    {
        timer.Stop();
        timer.Interval = 1000;
        timer.Enabled = true;
    
        /* ... Some code ... */
    
    
        return timer;
    }
    
    void timer_Tick(object sender, EventArgs e, Sharp sharp)
    {
        if (CheckDown())
        {
            /* ... Some code ... */
        }
        else
        {
            Watch().Start();
        }
    }
