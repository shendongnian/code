    public sealed class Singleton
        {
            private static int counter = 0;
            private Singleton()
            {
                counter++;
                Console.WriteLine("Counter Value " + counter.ToString());
            }
            private static readonly Singleton singleInstance = new Singleton(); 
            
            public static Singleton GetInstance
            {
                get
                {
                    return singleInstance;
                }
            }
            public void PrintDetails(string message)
            {
                Console.WriteLine(message);
            }
        }
