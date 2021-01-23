        var subject = new Subject<Item>();
        IObserver<Item> newItems = subject;
        IObservable<T> itemsChanged = subject.SelectMany(item => item.ObserveItemChanged);
        itemsChanged.Subscribe(_ => Console.WriteLine("change"));
        // add items
        newItems.OnNext(item1);
        newItems.OnNext(item2);
