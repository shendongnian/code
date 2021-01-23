        public System.Timers.Timer MyTimer { get; set; }
        int counter;
        public Form2_Load()
        {
            MyTimer = new System.Timers.Timer();
            MyTimer.Interval = 1000;
            MyTimer.Elapsed+=new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
            MyTimer.Start();
        }
        void  myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (++counter == 30)
	        {
                //do pic
                this.Close();
	        }
        }
