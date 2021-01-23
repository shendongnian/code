    public class Range<T>
    {
        public Range(T min, T max)        
        {
            Min = min;
            Max = max;
        }
    
        public T Min { get; private set; }
        public T Max { get; private set; }
    }
