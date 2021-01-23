    public class JobTaskMock
    {
        public int CancelCount = 0;
        TestScheduler _Scheduler;
        IObservable<Unit> _Ticker;
        public JobTaskMock( TestScheduler s )
        {
            _Scheduler = s;
            _Ticker = _Scheduler.CreateTickObserver(0, 1000, 10);
        }
        public async Task<string> JobTask
            ( CancellationToken token
            , string input
            )
        {
            if ( input == "C" || input == "E" )
            {
                var t = await _Ticker.TakeWhile(v => !token.IsCancellationRequested);
                CancelCount++;
                return input;
            }
            return input;
        }
    }
