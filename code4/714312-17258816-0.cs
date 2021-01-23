    public static Task Delay(int millisecondsDelay, CancellationToken cancellationToken)
    {
        if (millisecondsDelay < -1)
        {
            throw new ArgumentOutOfRangeException("millisecondsDelay", Environment.GetResourceString("Task_Delay_InvalidMillisecondsDelay"));
        }
        if (cancellationToken.IsCancellationRequested)
        {
            return FromCancellation(cancellationToken);
        }
        if (millisecondsDelay == 0)
        {
            return CompletedTask;
        }
        DelayPromise state = new DelayPromise(cancellationToken);
        if (cancellationToken.CanBeCanceled)
        {
            state.Registration = cancellationToken.InternalRegisterWithoutEC(delegate (object state) {
                ((DelayPromise) state).Complete();
            }, state);
        }
        if (millisecondsDelay != -1)
        {
            state.Timer = new Timer(delegate (object state) {
                ((DelayPromise) state).Complete();
            }, state, millisecondsDelay, -1);
            state.Timer.KeepRootedWhileScheduled();
        }
        return state;
    }
