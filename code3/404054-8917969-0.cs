    public class MyClass
    {
        private bool myPropSet = false;
        private int myProp;
        public int MyProp
        {
            get
            {
                return myProp;
            }
            set
            {
                if (!myPropSet)
                {
                    myPropSet = true;
                    myProp = value;
                }
            }
        }
        
