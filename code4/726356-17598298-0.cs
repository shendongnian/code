    internal class Program
    {
        private static void Main(string[] args)
        {
            var cancellationToken = new CancellationTokenSource();
            Task.Factory.StartNew(() => TaskCode(cancellationToken),
                                  cancellationToken.Token);
            Console.ReadLine();
            cancellationToken.Cancel();
            Console.WriteLine("End");
            Console.ReadLine();
        }
        private static async void TaskCode(CancellationTokenSource cancellationToken)
        {
            while (true)
            {
                const int interval = 1;
                if (cancellationToken.IsCancellationRequested) return;
                try
                {
                    await Task.Delay(interval*1000, cancellationToken.Token);
                }
                catch (TaskCanceledException ex)
                {
                    return;
                }
                if (cancellationToken.IsCancellationRequested) return;
                //SOME WORK HERE
                Console.WriteLine("Tick");
            }
        }
    }
