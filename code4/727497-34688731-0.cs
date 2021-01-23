    using System.Reactive.Linq;
    using System.Reactive.Threading.Tasks;
    ...
    public static bool WaitForSingleEvent<TEvent>(this CancellationToken token, Action<TEvent> onEvent, Action<Action<TEvent>> subscribe, Action<Action<TEvent>> unsubscribe, int msTimeout, Action initializer = null) {
        var task = Observable.FromEvent(subscribe, unsubscribe).FirstAsync().ToTask();
        if (initializer != null) {
            initializer();
        }
        try {
            var finished = task.Wait(msTimeout, token);
            if (finished) onEvent(task.Result);
            return finished;
        } catch (OperationCanceledException) { return false; }
    }
