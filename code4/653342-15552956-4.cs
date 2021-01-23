    private IDisposable InvokeStart(IScheduler self, object state)
    {
        this._pendingTickCount = 1;
        SingleAssignmentDisposable disposable = new SingleAssignmentDisposable();
        this._periodic = disposable;
        disposable.Disposable = self.SchedulePeriodic<long>(1L, this._period, new Func<long, long>(this.Tock));
        try
        {
            base._observer.OnNext(0L);
        }
        catch (Exception exception)
        {
            disposable.Dispose();
            exception.Throw();
        }
        if (Interlocked.Decrement(ref this._pendingTickCount) > 0)
        {
            SingleAssignmentDisposable disposable2 = new SingleAssignmentDisposable {
                Disposable = self.Schedule<long>(1L, new Action<long, Action<long>>(this.CatchUp))
            };
            return new CompositeDisposable(2) { disposable, disposable2 };
        }
        return disposable;
    }
