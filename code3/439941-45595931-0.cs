    class MyClass {
        public event EventHandler MyEvent;
        public void Method() {
            OnDownloadCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
