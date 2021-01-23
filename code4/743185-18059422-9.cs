    public class A 
    {
        private static readonly int? x;
    
        public int X
        {
            get
            {
                return x ?? 0;
            }
        }
    }
