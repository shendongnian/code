        private void TimeEvent()
        {            
            //place your timer callback code here
        }
        public void SetupTimer()
        {            
            //set up timer to run every second
            PCLTimer _pageTimer = new PCLTimer(new Action(TimeEvent), TimeSpan.FromMilliseconds(-1), TimeSpan.FromSeconds(1));
            
            //timer starts one second from now
            _pageTimer.Change(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
         
        }
