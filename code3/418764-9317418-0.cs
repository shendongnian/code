        var subject = new Subject<double>();
        var collection = new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var observableCollection = collection
            .ToObservable()
            .Concat(subject); //at the end of the original collection, add the subject
        observableCollection.Subscribe(OnNext);
        //now I want to add 100, 101, 102 which should reach my observers
        subject.OnNext(100);
        subject.OnNext(101);
        subject.OnNext(102);
