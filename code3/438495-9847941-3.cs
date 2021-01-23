    public interface ITimer {
        bool IsEnabled { set; }
        double Interval { set; }
        event Action Tick;
    }
    public sealed class Timer : ITimer {
        readonly DispatcherTimer _timer;
        public Timer() {
            _timer = new DispatcherTimer();
            _timer.Tick += (sender, e) => OnTick();
        }
        public double Interval {
            set { _timer.Interval = TimeSpan.FromMilliseconds(value); }
        }
        public event Action Tick;
        public bool IsEnabled {
            set { _timer.IsEnabled = value; }
        }
        void OnTick() {
            var handler = Tick;
            if (handler != null) {
                handler();
            }
        }
    }
    public sealed class MockTimer : ITimer {
        public event Action Tick;
        public bool IsEnabled { private get; set; }
        public double Interval { set { } }
        public void OnTick() {
            if (IsEnabled) {
                var handler = Tick;
                if (handler != null) {
                    handler();
                }
            }
        }
    }
    public sealed class DelayedAction {
        readonly Action _action;
        readonly int _delay;
        public DelayedAction(int delay, Action action) {
            _delay = delay;
            _action = action;
        }
        public Action Action {
            get { return _action; }
        }
        public int Delay {
            get { return _delay; }
        }
    }
