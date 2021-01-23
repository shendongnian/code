    public class Something
    {
        private string _Message;
        public string Message
        {
            get { return _Message;
            set
            {
                if (_Message != value)
                {
                    _Message = value;
                    CallSomeMethod();
                }
            }
        }
        public void CallSomeMethod()
        {
            Debug.WriteLine("Message is now: " + Message);
        }
    }
