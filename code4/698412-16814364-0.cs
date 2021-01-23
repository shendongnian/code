    private int elapsedTime; // initialized with zero
    private Timer timer = new System.Windows.Forms.Timer();
    public static int Main() 
    {
        timer.Interval = 1000; // interval is 1 second
        timer.Tick += timer_Tick;
        timer.Start();
    }
    private void timer_Tick(Object source, EventArgs e) {
        elapsedTime++; // increase elapsed time 
        DrawBall();
    }
