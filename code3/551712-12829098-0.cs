    System.Timers.Timer timer = new System.Timers.Timer();
        public Context() {
            timer.Interval = 1;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);   
           
            timer.Start();
            Thread t = new Thread(ChangeTimerTest);
            t.Start();
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(System.DateTime.Now.ToLongTimeString());
        }
       
        private void ChangeTimerTest() {
            System.Diagnostics.Debug.WriteLine("thread run");
            timer.Interval = 2000;
        }
