     class PauseExample
        {
            static void Main(string[] args)
            {
                int a = 90;
                int b = 0;
    
                try
                {
                    int c = a / b;
                }
                catch
                {
                    Console.WriteLine("In catch");
    
                    System.Threading.Thread.Sleep(5000); //waits for 5 seconds
    
                    Console.WriteLine("Out of catch");
                }
            }
        }
