    class Program
        {
            static void Main(string[] args)
            {
    
                var timer = new Timer(TimerProc, null, 1000, 1000);
    
                Console.ReadLine();
            }
    
            static public void TimerProc(object state)
            {
                Console.WriteLine("Called");
                for (int i = 0; i <= 6; i++)
                {
                    Console.WriteLine(i);
                }
    
            }
        }
