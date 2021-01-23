    public class Foo
    {
        private ReplaySubject<bool> whenBarChanged = new ReplaySubject<bool>();
        public IObservable<bool> WhenBarChanged
        {
            get { return whenBarChanged.AsObservable(); }
        }
    }
