    public abstract class PrinterProvider
    {
        public string Password{get;private set;}
        public abstract bool connect(string port);
        public bool IsConnected()
        {
            return true;
        }
    }
