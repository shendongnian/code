    public class MyClass {
        private ITimer timer;
    
        public ITimer Timer {
            get { return timer; }
            set { SetDefaultTimer(value); }
        }
    
        private void SetDefaultTimer(ITimer timer) {
            timer.Interval = 1000;
            // other default properties
            
            // assign
            this.timer = timer;
        }
    }
