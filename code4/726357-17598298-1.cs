    internal class Program
    {
        private static void Main(string[] args)
        {
            var cancellationToken = new CancellationTokenSource();
            Task.Factory.StartNew(() => TaskCode(cancellationToken.Token),
                                  cancellationToken.Token);
            Console.ReadLine();
            cancellationToken.Cancel();
            Console.WriteLine("End");
            Console.ReadLine();
        }
        private static async Task TaskCode(CancellationToken cancellationToken)
        {
            while (true)
            {
                const int interval = 1;
                if (cancellationToken.IsCancellationRequested) return;
                await Task.Delay(interval*1000, cancellationToken);
                if (cancellationToken.IsCancellationRequested) return;
                //SOME WORK HERE
                Console.WriteLine("Tick");
            }
        }
    }
