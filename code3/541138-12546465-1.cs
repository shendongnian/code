        public static IObservable<IList<T>> Zip<T>(this IList<IObservable<T>> observables)
        {
            return Observable.Create<IList<T>>(observer =>
            {
                List<List<T>> store = new List<List<T>>(Enumerable.Range(1, observables.Count).Select(_ => new List<T>()));
                return new CompositeDisposable(observables.Select((o, i) => 
                    o.Subscribe(value =>
                    {
                        lock (store)
                        {
                            store[i].Add(value);
                            if (store.All(list => list.Count > 0))
                            {
                                observer.OnNext(store.Select(list => list[0]).ToList());
                                store.ForEach(list => list.RemoveAt(0));
                            }
                        }
                    }))
                );
            });
        }
