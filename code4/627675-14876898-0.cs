    public class RandomContainer<T> 
    {
        private Random _random = new Random();
        private Dictionary<T, int> _objects = new Dictionary<T, int>();
        private int _weightSum;
        public RandomContainer()
        {           
        }
        public void Add(T obj, int weight)
        {          
            _objects.Add(obj, weight);
            _weightSum += weight;
        }
        public T Get()
        {
            int sumExtra = 0;
            int rand = _random.Next(1, _weightSum);
            foreach(var kvp in _objects)
            {
                if(rand < kvp.Value + sumExtra)
                    return kvp.Key;
                sumExtra += kvp.Value;
            }
            return default(T); // This shouldn't be reached
        }
    }
