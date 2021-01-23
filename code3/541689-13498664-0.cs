        public class PCLTimer
        {
            private Timer _timer;
    
            private Action _action;
    
            public PCLTimer(Action action, TimeSpan dueTime, TimeSpan period)
            {
                _action = action;
    
                _timer = new Timer(PCLTimerCallback, null, new TimeSpan(0), TimeSpan.FromSeconds(1));           
            }
    
            private void PCLTimerCallback(object state)
            {
                _action.Invoke();
            }
    
            public bool Change(TimeSpan dueTime, TimeSpan period)
            {
                return _timer.Change(dueTime, period);
            }
        }
