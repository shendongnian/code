    public class MyClass
    {
        private List<object> _myList = new List<object>();
    
        public IList<object> MyList { get { return _myList.AsReadOnly(); } }
    }
