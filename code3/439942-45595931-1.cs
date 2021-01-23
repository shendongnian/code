    class MyClass {
        public event EventHandler MyEvent;
        public void Method() {
            MyEvent?.Invoke(this, EventArgs.Empty);
        }
    }
