    public class User {
        public ExpandoObject _Data = new ExpandoObject();
        
        public dynamic Data {
            get { return _Data; }
        }
    }
