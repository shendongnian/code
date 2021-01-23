    // create a global _timer object
    static Timer _timer; // From System.Timers
    private void button1_Click(object sender, EventArgs e)
    {
        
        label1.Text = "Magic";
        // Thread.Sleep(3000); // don't do Thread.Sleep()!
        label1.Visible = false;
        Start();
    }
    static void Start()
    {
        label1.Visible = true;
        _timer = new Timer(3000); // Set up the timer for 3 seconds
        _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        _timer.Enabled = true; // Enable it
    }
    static void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        label1.Visible = false;
        _timer.Stop();
    }
