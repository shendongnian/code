    public class PropertyExample
    {
        private int myIntField = 0;
    
        public int MyInt
        {
            get
            {
                return myIntField;
            }
            protected set
            {
                DoSomeValidation(value)
                {
                    myIntField = value;
                }
            }
        }
    }
