    public class CircularQuene<T> : List<T>
    {
        public CircularQuene(int maxCount)
        {
            count = maxCount;
        }
        new public void Add(T variable)
        {
            base.Add(variable);
            if (Count > count)
            {
                RemoveAt(0);
            }
        }
        private int count;
        public int MaxCount
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
    }
