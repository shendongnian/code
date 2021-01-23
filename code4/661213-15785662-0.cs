    class Program
    {
        static void Main(string[] args)
        {
            using(YourClass y = new YourClass())
            {
            }
        }
    }
    class YourClass : IDisposable
    {
        public void Dispose()
        {
 
        }
    }
