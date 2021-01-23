    public class MyType
    {
        private object[] backingArray = new object[3];
        public object this[int index]
        {
            get { return backingArray[index]; }
            set { backingArray[index] = value; }
        }
    
        public object X 
        {
            get { return backingArray[0]; }
            set { backingArray[0] = value; }
        }
        public object Y
        {
            get { return backingArray[1]; }
            set { backingArray[1] = value; }
        }
        public object Z 
        {
            get { return backingArray[2]; }
            set { backingArray[2] = value; }
        }
    }
