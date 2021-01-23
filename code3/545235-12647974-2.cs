    [DataContract]
    public class MyServiceFault
    {
        private string _message;
        public MyServiceFault(string message)
        {
            _message = message;
        }
        [DataMember]
        public string Message { get { return _message; } set { _message = value; } }
    }
