    public class Foo
    {
        private List<int> toBeProtected = new List<int>();
        private object locker = new object();
        
        public void Add(int value)
        {
            lock(locker)
            {
                toBeProtected.Add(value);
            }
        }
    }
