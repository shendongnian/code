    public static class RxActionUtilities
    {
        /// <summary>
        /// Makes an observable out of an action. Only at subscription the task will be executed. 
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// RxActionUtilities.MakeObservable_3(myAction)
        ///                  .SubscribeOn(_schedulerProvider.TaskPoolScheduler)
        ///                  .Subscribe(....);
        /// 
        /// ]]>
        /// </code>
        /// </example>
        public static IObservable<Unit> MakeObservable_3(Action action)
        {
            return Observable.Create<Unit>(observer =>
                {
                    try
                    {
                        action();
                        observer.OnNext(Unit.Default);
                        observer.OnCompleted();
                    }
                    catch (Exception ex)
                    {
                        observer.OnError(ex);
                    }
                    return Disposable.Empty;
                });
        }
    }
