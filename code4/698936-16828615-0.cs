    public class RangeClass
    {    
        public int Min { get; private set; }
        public int Max { get; private set; }
    
        public RangeClass(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
