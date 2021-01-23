        Timer myTimer;
        static volatile bool isRunning;
        public OnboardingTaskService()
        {
             myTimer= new Timer();
             myTimer.Interval = 60000;
             myTimer.Elapsed += myTimer_Elapsed;
             myTimer.Start();
        }
       private void myTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isRunning) return;
            isRunning = true;
            try
            {
                //Your Code....
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            finally { isRunning = false; }
        }
