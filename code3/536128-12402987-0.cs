       myTimer.Tick += new EventHandler(TimerEventProcessor);       
       myTimer.Interval = 1350;
       myTimer.Start();
       private void TimerEventProcessor(...){          
         label1.Text = "...";
       }
