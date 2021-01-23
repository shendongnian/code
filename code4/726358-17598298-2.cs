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
            while (true)
            {
                TimeSpan interval = TimeSpan.FromSeconds(1);
                if (cancellationToken.IsCancellationRequested) return;
                await Task.Delay(interval, cancellationToken);
                if (cancellationToken.IsCancellationRequested) return;
                //SOME WORK HERE
                Console.WriteLine("Tick");
            }
        }
    }
