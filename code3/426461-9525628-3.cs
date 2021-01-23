    public class PollingListener
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        public event EventHandler<EventArgs> Polled;
        public PollingListener(System.Windows.Forms.Control consumer)
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(PollNow);
            timer.Start();
            consumerContext = consumer;
        }
        System.Windows.Forms.Control consumerContext;
        void PollNow(object sender, EventArgs e)
        {
            var temp = Polled;
            if ((temp != null) && (null != consumerContext))
            {
                consumerContext.BeginInvoke(new Action(() =>
                    {
                        Polled(this, new EventArgs());
                    }));
            }
        }
    }
