    public static IObservable<TOut> ZipWithExpiry<TLeft, TRight, TOut>(
                        IObservable<TLeft> left, 
                        IObservable<TRight> right, 
                        Func<TLeft, TRight, TOut> selector, 
                        TimeSpan validity)
            {
                return Observable.Zip(left.Timestamp(), right.Timestamp(), (l, r) => Tuple.Create(l, r))
                                 .Where(tuple => Math.Abs((tuple.Item1.Timestamp - tuple.Item2.Timestamp).TotalSeconds) < validity.TotalSeconds)
                                 .Select(tuple => selector(tuple.Item1.Value, tuple.Item2.Value));
            }
