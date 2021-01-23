    public class Base
    {
        public virtual int MyInt { get; set; }
    }
    public class Child : Base
    {
        private int anotherInt;
        public override int MyInt
        {
            get { return anotherInt; }
            set { anotherInt = value; }
        }
    }
