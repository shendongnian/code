    public class Program
        {
            static void Main(string[] args)
            {
                Go();
            }
            public static void Go()
            {
                GoAsync();
                Console.ReadLine();
            }
            public static async void GoAsync()
            {
    
                Console.WriteLine("Starting");
    
                var task1 = Sleep(5000);
                var task2 = Sleep(3000);
    
                int[] result = await Task.WhenAll(task1, task2);
    
                Console.WriteLine("Slept for a total of " + result.Sum() + " ms");
               
            }
    
            private async static Task<int> Sleep(int ms)
            {
                Console.WriteLine("Sleeping for {0} at {1}", ms, Environment.TickCount);
                await Task.Delay(ms);
                Console.WriteLine("Sleeping for {0} finished at {1}", ms, Environment.TickCount);
                return ms;
            }
        }
