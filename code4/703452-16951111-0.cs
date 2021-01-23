    public class DataAquisitionSimulator:IObservable<int>
    {
        private static readonly Random RealTimeMarketData = new Random();
        public IDisposable Subscribe(IObserver<int> observer)
        {
            for (int i = 0; i < 10; i++)
            {
                int data = RealTimeMarketData.Next();
                observer.OnNext(data);
                Thread.Sleep(RealTimeMarketData.Next(5000));
            }
            observer.OnCompleted();
            return Disposable.Create(() => Console.WriteLine("cleaning up goes here"));
        }
    }
