    public class FooEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public FooEventArgs(string message)
        {
            Message = message;
        }
    }
