    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Concurrency;
    
    namespace MyProject
    {
    
        public static class ASync
        {
            public static void ThrowAway(Action todo)
            {
                ThrowAway(todo, null);
            }
    
            public static void ThrowAway(Action todo, Action<Exception> onException)
            {
                if (todo == null)
                    return;
    
                Run<bool>(() =>
                {
                    todo();
                    return true;
                }, null, onException);
            }
    
            public static bool Fork(Action<Exception> onError, params Action[] toDo)
            {
                bool errors = false;
                var fork = Observable.ForkJoin(toDo.Select(t => Observable.Start(t).Materialize()));
                foreach (var x in fork.First())
                    if (x.Kind == NotificationKind.OnError)
                    {
                        if(onError != null)
                            onError(x.Exception);
    
                        errors = true;
                    }
    
                return !errors;
            }
    
            public static bool Fork<T>(Action<Exception> onError, IEnumerable<T> args, Action<T> perArg)
            {
                bool errors = false;
                var fork = Observable.ForkJoin(args.Select(arg => Observable.Start(() => { perArg(arg); }).Materialize()));
                foreach (var x in fork.First())
                    if (x.Kind == NotificationKind.OnError)
                    {
                        if (onError != null)
                            onError(x.Exception);
    
                        errors = true;
                    }
    
                return !errors;
            }
    
    
            public static void Run<TResult>(Func<TResult> todo, Action<TResult> continuation, Action<Exception> onException)
            {
                bool errored = false;
                IDisposable subscription = null;
    
                var toCall = Observable.ToAsync<TResult>(todo);
                var observable =
                    Observable.CreateWithDisposable<TResult>(o => toCall().Subscribe(o)).ObserveOn(Scheduler.Dispatcher).Catch(
                    (Exception err) =>
                    {
                        errored = true;
    
                            if (onException != null)
                                onException(err);
    
    
                            return Observable.Never<TResult>();
                    }).Finally(
                    () =>
                    {
                        if (subscription != null)
                            subscription.Dispose();
                    });
    
                subscription = observable.Subscribe((TResult result) =>
                {
                    if (!errored && continuation != null)
                    {
                        try
                        {
                            continuation(result);
                        }
                        catch (Exception e)
                        {
                            if (onException != null)
                                onException(e);
                        }
                    }
                });
            }
        }
    }
