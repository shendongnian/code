    public class MyCustomInt
    {
        public bool IsMutable { get; set; }
        private int _myInt;
        public int MyInt 
        { 
            get
            {
                return _myInt;
            } 
            set
            {
                if(IsMutable)
                {
                    _myInt = value;
                }
            }
        }
        public MyCustomInt(int val)
        { 
            MyInt = val;
            IsMutable = true;
        }
    }
