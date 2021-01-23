        System.Threading.Timer timerFunc = null;
        public void processArchives()
        {
            initializeTimer();
            while (!CSEmailQueues.StoppingService) //is
                Thread.Sleep(CSEmailQueues.sleeptime); 
            timerFunc.Dispose();
            return;
        }
        private void initializeTimer()
        {
            var now = DateTime.Now;
            var tomorrow = now.AddDays(1);
            var durationUntilMidnight = tomorrow.Date - now;
            if (timerFunc != null) timerFunc.Dispose();
            timerFunc = new System.Threading.Timer(o => { attemptArchivalProcess(); }, null, TimeSpan.Zero, durationUntilMidnight);
        }
        private void attemptArchivalProcess()
        {
            //Do Work
            initializeTimer(); //re-start timer to process tomorrow
        }
