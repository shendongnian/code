    private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public void Context() {
            timer.Interval = 1;
            timer.Tick += timer_Tick;
            timer.Start();
            Thread t = new Thread(ChangeTimerTest);
            t.Start();
        }
        delegate void intervalChanger();
        void ChangeInterval()
        {
            timer.Interval = 2000;
        }
        void IntervalChange()
        {
            this.Invoke(new intervalChanger(ChangeInterval));
        }
        private void ChangeTimerTest() {
            System.Diagnostics.Debug.WriteLine("thread run");
            IntervalChange();
        }
        private void timer_Tick(object sender,EventArgs args) {
            System.Diagnostics.Debug.WriteLine(System.DateTime.Now.ToLongTimeString());
        }
