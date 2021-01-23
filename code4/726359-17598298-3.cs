    internal class Program
    {
        private static void Main(string[] args)
        {
            var cancellationToken = new CancellationTokenSource();
            TaskCode(cancellationToken.Token);
            Console.ReadLine();
            cancellationToken.Cancel();
            Console.WriteLine("End");
            Console.ReadLine();
        }
        private static async Task TaskCode(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var interval = TimeSpan.FromSeconds(1);
                await Task.Delay(interval, cancellationToken);
                //SOME WORK HERE
                Console.WriteLine("Tick");
            }
        }
    }
