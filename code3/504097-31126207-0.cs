        public static IObservable<IReadOnlyList<Timestamped<T>>> SlidingWindow<T>(this IObservable<Timestamped<T>> self, TimeSpan length)
        {
            return self.Scan(new LinkedList<Timestamped<T>>(),
                             (ll, newSample) =>
                             {
                                 ll.AddLast(newSample);
                                 var oldest = newSample.Timestamp - length;
                                 while (ll.Count > 0 && list.First.Value.Timestamp < oldest)
                                     list.RemoveFirst();
                                 return list;
                             }).Select(l => l.ToList().AsReadOnly());
        }
