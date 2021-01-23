    private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval=1000; // time in milliseconds
            timer.Tick+=new EventHandler(timer_Tick);
        }
        void timer_Tick(object sender, EventArgs e)
        {
           //Do your update here
        }
