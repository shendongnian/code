    public class ClassB
    {
        private readonly ClassA _myClassA = new ClassA();
        private string _myString;
        public string MyString 
        { 
            get
            {
                // your logic here
                return _myString;
            } 
            set 
            {
                // your logic here
                _myString = value;
            }
        }
        public string MyStringA { get { return _myClassA.MyString;}}
        public int MyIntA { get { return _myClassA.MyInt; }}
    }
