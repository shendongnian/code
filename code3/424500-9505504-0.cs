    public class MyViewModel {
        private volatile int notifyPropertylocks = 0; // number of locks
        protected void NotifyPropertyChanged(string propertyName) {
            if (this.notifyPropertylocks == 0) { // check the counter
                this.NotifyPropertyChanged(...);
            }
        }
        
        protected IDisposable PreventNotifyPropertyChanges() {
            return new PropertyChangeLock(this);
        }
        
        public class PropertyChangeLock : IDisposable {
            MyViewModel vm;
            
            // creating this object will increment the lock counter
            public PropertyChangeLock(MyViewModel vm) {
                this.vm = vm;
                this.vm.notifyPropertylocks += 1;
            }
            
            // disposing this object will decrement the lock counter
            public void Dispose() {
                if (this.vm != null) {
                    this.vm.notifyPropertylocks -= 1;
                    this.vm = null;
                }
            }
        }
    }
