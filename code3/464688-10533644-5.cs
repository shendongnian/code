    public FooEventArgs : EventArgs
    {
        public FooEventArgs(string message)
        {
            Message = message;
        }
    
        public string Message { get; private set; }
    }
