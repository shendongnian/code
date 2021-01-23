    public class Thingy
    {
        private BehaviorSubject<bool> _statusSubject = new BehaviorSubject<bool>(false);    
        public IObservable<bool> Status
        {
            get
            {
                return _statusSubject;
            }
        }
        
        public void Init()
        {
            var c = new object();
            new Underlying().GetDeferredObservable(c).Subscribe(_statusSubject);
        }
    }
