    System.Exception: Exception of type 'System.Exception' was thrown.
    
       at yournamespace.MainWindow.<Button_Click>b__0(Int64 r) in path\MainWindow.xaml.cs:line XX
       at System.Reactive.AnonymousObserver`1.Next(T value)
       at System.Reactive.AbstractObserver`1.OnNext(T value)
       at System.Reactive.AnonymousObservable`1.AutoDetachObserver.Next(T value)
       at System.Reactive.AbstractObserver`1.OnNext(T value)
       at System.Reactive.Linq.Observable.<>c__DisplayClass2ff`1.<>c__DisplayClass301.<Take>b__2fe(TSource x)
       at System.Reactive.AnonymousObserver`1.Next(T value)
       at System.Reactive.AbstractObserver`1.OnNext(T value)
       at System.Reactive.AnonymousObservable`1.AutoDetachObserver.Next(T value)
       at System.Reactive.AbstractObserver`1.OnNext(T value)
       at System.Reactive.Linq.Observable.<>c__DisplayClass35b.<>c__DisplayClass35d.<Timer>b__35a()
       at System.Reactive.Concurrency.Scheduler.Invoke(IScheduler scheduler, Action action)
       at System.Reactive.Concurrency.ThreadPoolScheduler.<>c__DisplayClass5`1.<Schedule>b__3(Object _)
       at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
       at System.Threading._TimerCallback.PerformTimerCallback(Object state)
