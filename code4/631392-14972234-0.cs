    public class MyRandomObject
    {
        private readonly Random _rnd = new Random();
        
        public int Next()
        {
            lock (_rnd)
            {
                return _rnd.Next();
            }
        }
    }
