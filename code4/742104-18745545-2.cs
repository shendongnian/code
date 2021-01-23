    public class TickerObservable : IExcelObservable
    {
        private static Timer timer = ..... ; // assume it is up & running & shared
        public IDisposable Subscribe(IExcelObserver observer)
        {
            ElapsedEventHander hd = (s, e) => observer.OnNext(DateTime.Now.ToString());
            timer.Elapsed += hd;
            return new TickerDisposable(timer, hd);  
        }
    }
    public class TickerDisposable : IDisposable
    {
        private Timer ticky;
        private ElapsedEventHander handler;
        public TickerDisposable(Timer timer, ElapsedEventHander hd)
        {
            ticky = timer;
            handler = hd;
        }
        public void Dispose()
        {
            if(ticky != null && handler != null)
                ticky.Elapsed -= handler;
        }
    }
