    using (var iterator = subscriptions.GetEnumerator())
    {
        while (iterator.MoveNext())
        {
            var s = iterator.Current;
            s.Subscriber.OnNext(args);
        }
    }
