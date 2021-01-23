        static void Main(string[] args)
        {
            using (Test.Instance)
            {
                
            }  
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }
        public class Test:IDisposable
        {
            public static Test Instance = new Test();
            public void Dispose()
            {
                Console.WriteLine("Disposed");
            }
        }
