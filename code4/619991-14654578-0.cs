    public abstract class Widget : Node
    {
        private static int UniqueCount = 0;
        protected int Unique { private set; get; }
    
        protected Widget() : base()
        {
            Unique = Interlocked.Increment(ref UniqueCount);
        }  
    }
