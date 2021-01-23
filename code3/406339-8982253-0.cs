    public static class MyAwesomeFooFactory
    {
        readonly static Subject<SomeEventArgs> someEvents = new Subject<SomeEventArgs>();
        public static IObservable<SomeEventArgs> NotificationsFromAllTheEvents { get { return someEvent; }}
        public static Foo MakeANewFoo()
        {
            var ret = new Foo();
            ret.SomeEvent.Subscribe(someEvents); // NB: We never unsubscribe, *evar*
            return ret;
        }
    }
