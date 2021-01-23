    System.Threading.Timer t;
    int seconds = 0;
    public void start() {
        TimerCallback tcb = new TimerCallback(tick);
        t = new System.Threading.Timer(tcb);
        t.Change(0, 1000);          
    }
    public void tick(object o)
    {
        seconds++;
        if (seconds == 60)
        {
            // do something
        }
    }
