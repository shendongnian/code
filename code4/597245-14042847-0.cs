    public class SocksEntry
    {
        private readonly object sizeLock = new object();
    
        public int SizeA { get; private set; }
        public int SizeB { get; private set; }
    
        public void UpdateSocksSize(int a, int b)
        {
           lock (sizeLock)
           {
              SizeA = a;
              SizeB = b;
           }
        }    
    }
