    class YourControl {
        public class YourControlEventArgs: EventArgs {
            public TimeSpan Elapsed;
            public YourControlEventArgs(TimeSpan t) {
                this.Elapsed = t;
            }
        }
        
        public event EventHandler<YourControlEventArgs> Success;
        
        protected void OnSuccess(TimeSpan t) {
            if(this.Success != null)
                this.Success(this, new YourControlEventArgs(t));
        }
    }
