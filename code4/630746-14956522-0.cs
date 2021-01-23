    public abstract class ResponseType
    {
        private readonly int _accept;
        private readonly int _reject;
    
        protected ResponseType(int accept, int reject)
        {
            _accept = accept;
            _reject = reject;
        }
    
        public int Accept { get { return _accept; } }
        public int Reject { get { return _reject; } }
    }
    
    public class ResponseType1 : ResponseType
    {
        public ResponseType1() : base(10, 11) { }
    }
    
    public class ResponseType2 : ResponseType
    {
        public ResponseType2() : base(12, 13) { }
    }
    
    public class ResponseType3 : ResponseType
    {
        public ResponseType3() : base(14, 15) { }
    }
