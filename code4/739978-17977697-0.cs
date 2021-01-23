    public class Publisher
    {
        private readonly Subject<Foo> _topic1;
        /// <summary>Observe Foo values on this topic</summary>
        public IObservable<Foo> FooTopic
        {
           get { return _topic1.AsObservable(); }
        }
        private readonly IObservable<long> _topic2;
        /// <summary>Observe the current time whenever our clock ticks</summary>
        public IObservable<DateTime> ClockTickTopic
        {
            get { return _topic2.Select(t => DateTime.Now); }
        }
        public Publisher()
        {
             _topic1 = new Subject<Foo>();
             // tick once each second
             _topic2 = Observable.Interval(TimeSpan.FromSeconds(1));
        }
        /// <summary>Let everyone know about the new Foo</summary>
        public NewFoo(Foo foo) { _topic1.OnNext(foo); }
    }
    // interested code...
    Publisher p = ...;
    p.FooTopic.Subscribe(foo => ...);
    p.ClickTickTopic.Subscribe(currentTime => ...);
    // count how many foos occur during each clock tick
    p.FooTopic.Buffer(p.ClockTickTopic)
        .Subscribe(foos => Console.WriteLine("{0} foos during this interval", foos.Count));
