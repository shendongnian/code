    public class Historgram<T> 
    {
        Dictionary<T, int> bins;
        public Historgram()
        {
            this.bins=new Dictionary<T, int>();
        }
        public void Add(T value)
        {
            if(bins.ContainsKey(value))
            {
                bins[value]++;
            }
            else
            {
                bins.Add(value, 1);
            }
        }
        public void Remove(T value)
        {
            if(bins.ContainsKey(value))
            {
                bins[value]--;
                if(bins[value]==0)
                {
                    bins.Remove(value);
                }
            }
        }
        public int this[T x]
        {
            get
            {
                if(bins.ContainsKey(x))
                {
                    return bins[x];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if(bins.ContainsKey(x))
                {
                    bins[x]=value;
                }
                else
                {
                    bins.Add(x, value);
                }
            }
        }
        public bool ContainsValue(T value) { return bins.ContainsKey(value); }
        public int Count { get { return bins.Count; } }
        public T[] Values { get { return bins.Keys.ToArray(); } }
        public int[] Quantities { get { return bins.Values.ToArray(); } }
    }
