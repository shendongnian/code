    public class SubjectTests
    {
        [Test]
        public void SubjectDoesNotRespectGrammar()
        {
            var subject = new Subject<int>();
            var spy = new ObserverSpy(Scheduler.Default);
            var sut = subject.Subscribe(spy);
            // Swap the following with the preceding to make this test pass
            //var sut = subject.Synchronize().Subscribe(spy);
            Task.Factory.StartNew(() => subject.OnNext(1));
            Task.Factory.StartNew(() => subject.OnNext(2));
            Thread.Sleep(2000);
            Assert.IsFalse(spy.ConcurrencyViolation);
        }
        private class ObserverSpy : IObserver<int>
        {
            private int _inOnNext;
            public ObserverSpy(IScheduler scheduler)
            {
                _scheduler = scheduler;
            }
            public bool ConcurrencyViolation = false;
            private readonly IScheduler _scheduler;
            public void OnNext(int value)
            {
                var isInOnNext = Interlocked.CompareExchange(ref _inOnNext, 1, 0);
                if (isInOnNext == 1)
                {
                    ConcurrencyViolation = true;
                    return;
                }
                var wait = new ManualResetEvent(false);
                _scheduler.Schedule(TimeSpan.FromSeconds(1), () => wait.Set());
                wait.WaitOne();
                _inOnNext = 0;
            }
            public void OnError(Exception error)
            {
            }
            public void OnCompleted()
            {
            }
        }
    }
