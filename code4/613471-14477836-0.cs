    public class MyEventArgs : EventArgs
    {
        public MyEventArgs(params object[] args)
        {
            Args = args;
        }
    
        public object[] Args { get; set; }
    }
