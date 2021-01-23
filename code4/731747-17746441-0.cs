        Timer Clock;
        Label LabelTime;
        public void MyTimer(Label o_TimeLabel) 
        {
          LabelTime = o_TimeLabel;
          Clock = new Timer(); 
          Clock.Tag = o_TimeLabel.Text; 
          Clock.Interval = 1000;
          Clock.Start(); 
          Clock.Tick += new EventHandler(Timer_Tick); 
        } 
        
        private void Timer_Tick(object sender, EventArgs eArgs) 
        { 
          LabelTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
        }
