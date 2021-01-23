        using System.Reactive;
        using System.Reactive.Subjects;
        using System.Reactive.Linq;
        var a = new Subject<int>();
        var b = new Subject<int>();
        var c = new Subject<int>();
        var test = 
            Observable.When(
                a.And(b).And(c).Then((a1, b1, c1) => new int[] { a1, b1, c1 })
            ).SelectMany(arr => arr.ToObservable());
        var sub = test.Subscribe(val => Console.Write("{0} ", val));
        a.OnNext(1);
        b.OnNext(2);
        c.OnNext(3);
        a.OnNext(1);
        c.OnNext(3);
        b.OnNext(2);
        
        c.OnNext(3);
        a.OnNext(1);
        b.OnNext(2);
        Console.ReadKey();
        sub.Dispose();
