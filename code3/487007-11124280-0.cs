    public class MyClass
    
        private Dictionary<string,string> _dict;
    
        public MyClass (Dictionary<string,string> dict)
        {
            _dict = dict;
        }
    
        public string FirstName { get { return _dict["FirstName"]; } }
        public string LastName { get { return _dict["LastName"]; } }
        ...
    }
