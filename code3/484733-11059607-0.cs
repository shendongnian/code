    class CountArgs:EventArgs
    {
       public int Count{get;set;} 
    
        public CountArgs(int c) { 
            Count = c; 
        }
    }
    class Game
    {
        
       public event EventHandler<CountArgs> CountChanged; // it is possible to define your own delegate here.
       int count;
       public int Count
       {
          get { return count;}
          set { 
                if (count != value) // Only raise the event if the value changes
                {
                     count = value;
                     RaiseCountChangedEvent(value);
                }
       }  
       void RaiseCountChangedEvent(int c)
       {
          if (CountChanged != null) // Check that at least one object is listening to the event
          {
              CountChanged(this,new CountArgs(c));
          }
       }
    }
