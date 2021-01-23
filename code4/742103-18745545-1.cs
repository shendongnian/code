    public class TickerObservable : IExcelObservable
    {
        public IDisposable Subscribe(IExcelObserver observer)
        {
            var timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += (s, e) => observer.OnNext(DateTime.Now.ToString());
            timer.Start();     
            return new TickerDisposable(timer);  
        }
    }
    public class TickerDisposable : IDisposable
    {
        private Timer ticky;
        public TickerDisposable(Timer timer)
        {
            ticky = timer;
        }
        public void Dispose()
        {
            if(ticky != null)
                ticky.Dispose(); // or Stop, or etc..
        }
    }
