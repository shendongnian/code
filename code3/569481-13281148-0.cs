    public class MyClass
    {
        private List<object> _myList = new List<object>();
    
        public IEnumerable<object> MyList { get { return _myList.GetEnumerator(); } }
    }
