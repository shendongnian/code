    public class FileManager
    {
        public event EventHandler<NotifyEventArgs> DoNotify;
            
        private void DoSomethingInterestingMethod() {
            //...
            // Let listeners know something interesting happened.
            var doNotify = DoNotify;
            if (doNotify != null) {
                doNotify(this, new NotifyEventArgs(errorLevel, message));
            }
           //...
        }
    }
    public class NotifyEventArgs : EventArgs
    {
        public NotifyEventArgs(int errorLevel, string statusMessage) {
            ErrorLevel = errorLevel;
            StatusMessage = statusMessage;
        }
    
        public int ErrorLevel { get; private set;}
        public string StatusMessage { get; private set; }
    }
