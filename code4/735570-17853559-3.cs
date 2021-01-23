    public static class TestSchedulerExtensions
    {
        public static IObservable<Unit> CreateTickObserver(this TestScheduler s, int startTick, int endTick, int tickStep)
        {
            var ticks = Enumerable.Repeat(1, Int32.MaxValue)
                .Select(( v, i ) => i * tickStep + startTick)
                .TakeWhile(v => v <= endTick)
                .Select(tick => ReactiveTest.OnNext(tick, Unit.Default));
            return s.CreateColdObservable(ticks.ToArray());
            
        }  
    }
