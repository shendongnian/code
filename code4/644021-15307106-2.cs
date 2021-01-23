    IObservable<TResult> Feedback<T, TResult>(this IObservable<T> seed,
                                              Func<T, IObservable<TResult>> produce,
                                              Func<TResult, IObservable<T>> feed)
        {
            return Observable.Create<TResult>(
                    obs =>
                    {
                        var ret = new CompositeDisposable();
                        Action<IDisposable> partComplete = 
                            d =>
                            {
                                ret.Remove(d);
                                if (ret.Count == 0) obs.OnCompleted();
                            };
                        Action<IObservable<T>, Action<T>> ssub =
                            (o, n) =>
                            {
                                var disp = new SingleAssignmentDisposable();
                                ret.Add(disp);
                                disp.Disposable = o.Subscribe(n, obs.OnError, () => partComplete(disp));
                            };
                        Action<IObservable<TResult>, Action<TResult>> rsub =
                            (o, n) =>
                            {
                                var disp = new SingleAssignmentDisposable();
                                ret.Add(disp);
                                disp.Disposable = o.Subscribe(n, obs.OnError, () => partComplete(disp));
                            };
                        Action<T> recurse = null;
                        recurse = s =>
                                  {
                                      rsub(produce(s),
                                           r => 
                                           {
                                               obs.OnNext(r);
                                               ssub(feed(r), recurse);
                                           });
                                  };
                        ssub(seed, recurse);
                        return ret;
                    });
        }
