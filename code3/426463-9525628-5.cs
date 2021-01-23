    public class PollingListener2
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        public event EventHandler<EventArgs> Polled;
        System.Windows.Forms.Timer formsTimer;
        public System.Threading.ManualResetEvent pollNotice;
        public PollingListener2()
        {
            pollNotice = new System.Threading.ManualResetEvent(false);
            formsTimer = new System.Windows.Forms.Timer();
            formsTimer.Interval = 100;
            formsTimer.Tick += new EventHandler(formsTimer_Tick);
            formsTimer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(PollNow);
            timer.Start();
        }
        void formsTimer_Tick(object sender, EventArgs e)
        {
            if (pollNotice.WaitOne(0))
            {
                pollNotice.Reset();
                var temp = Polled;
                if (temp != null)
                {
                    Polled(this, new EventArgs());
                }
            }
        }
        void PollNow(object sender, EventArgs e)
        {
            pollNotice.Set();
        }
    }
