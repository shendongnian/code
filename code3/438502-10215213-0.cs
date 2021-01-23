    public sealed partial class Form1 : Form {
        readonly Executor _executor = new Executor();
        public Form1() {
            InitializeComponent();
            _executor.Run(CreateAsyncHandler());
        }
        IEnumerable<IObservable<Unit>> CreateAsyncHandler() {
            while (true) {
                var i = 0;
                Text = (++i).ToString();
                yield return WaitTimer(500);
                Text = (++i).ToString();
                yield return WaitTimer(500);
                Text = (++i).ToString();
                yield return WaitTimer(500);
                Text = (++i).ToString();
            }
        }
        IObservable<Unit> WaitTimer(double ms) {
            return Observable.Timer(TimeSpan.FromMilliseconds(ms), new ControlScheduler(this)).Select(_ => Unit.Default);
        }
    }
    public sealed class Executor {
        IEnumerator<IObservable<Unit>> _observables;
        IDisposable _subscription = new NullDisposable();
        public void Run(IEnumerable<IObservable<Unit>> actions) {
            _observables = (actions ?? new IObservable<Unit>[0]).Concat(new[] {Observable.Never<Unit>()}).GetEnumerator();
            Continue();
        }
        void Continue() {
            _subscription.Dispose();
            _observables.MoveNext();
            _subscription = _observables.Current.Subscribe(_ => Continue());
        }
        public void Stop() {
            Run(null);
        }
    }
    sealed class NullDisposable : IDisposable {
        public void Dispose() {}
    }
