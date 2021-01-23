    public static class ObservableExtensions
    {
      public static IObservable<TSource> SubscribeOn<TSource>(
        this IObservable<TSource> source,
        bool doNotScheduleDisposal, 
        IScheduler scheduler)
      {
        if (!doNotScheduleDisposal)
        {
          return source.SubscribeOn(scheduler);
        }
        return Observable.Create<TSource>(observer =>
          {
            // Implementation is based on that of the native SubscribeOn operator in Rx
            var s = new SingleAssignmentDisposable();
            var d = new SerialDisposable();
            d.Disposable = s;
            s.Disposable = scheduler.Schedule(() =>
            {
              d.Disposable = source.SubscribeSafe(observer);
            });
            return d;
          });
      }
    }
