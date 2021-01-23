    public class MyException : Exception
    {
        private string myMessage = null;
        public override string Message
        {
            get
            { 
                return String.IsNullOrEmpty(myMessage) ? 
                     base.Message : 
                     myMessage; 
            }
        }
        public MyException(string message) : base()
        {
            myMessage = message;
        }
    }
