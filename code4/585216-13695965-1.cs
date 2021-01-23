    public class Counter
    {
        public int Value { get; private set; }
        public void Increment() 
        {
           Value = Value + 1;
        }
        public void Decrement() 
        {
          if (Value > 0) Value = Value - 1;
        }
        public Counter()
        {
           Value = 0;
        }
     }
