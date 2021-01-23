    public class Clock
    {  
    
        private int _hour;
    
        public void Increment()
        {
           if (_hour > 23)
              _hour = 0;
           else
              _hour++;
    
           // Raise event
        }
    
        public event EventHandler HourChanged;
    
        public int Hour { get { return _hour; } }
    }
