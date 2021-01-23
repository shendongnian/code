     private void MyFunction(int durationInSeconds)
        {
            MyTimer timer = new MyTimer();
            timer.Tick += new EventHandler(Timer_Tick); 
            timer.Interval = (1000) * (1);  // Timer will tick every second, you can change it if you want
            timer.Enabled = true;
            timer.stopTime = System.DateTime.Now.AddSeconds(durationInSeconds);
            timer.Start();
            //put your starting code here
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            MyTimer timer = (MyTimer)sender;
            if (System.DateTime.Now >= timer.stopTime)
            {
                timer.Stop();
                //put your ending code here
            }
        }
       
