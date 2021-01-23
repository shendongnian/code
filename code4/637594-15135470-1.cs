    class MyClass
    {
       private System.Timers.Timer _ScrollTimer;
       public MyClass()
       {
           _ScrollTimer= new System.Timers.Timer(100);
           _ScrollTimer.Elapsed += new ElapsedEventHandler(ScrollTimerElapsed);
       }
        
       private void ResetTimer()
       {
            _ScrollTimer.Stop();
            _ScrollTimer.Start();
       }
        
       private void Control_Scroll(object sender, ScrollEventArgs e, TimeSpan delay)
        {
            ResetTimer();
        }    
    
        private void ScrollTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _ScrollTimer.Stop();
            UpdateAnnotations();           
        }
    }
