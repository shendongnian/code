    public class Counter
    {
        public int Value { get; private set; }
        public void Increment() 
        {
           Value = Value + 1;
        }
        public void Decrement() 
        {
           Value = Value - 1;
        }
        public Counter()
        {
           Value = 0;
        }
     }
