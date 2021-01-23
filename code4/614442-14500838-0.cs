    public class Parent
    {
        private int test = 123;
        public virtual int TestProperty
        {
            // Notice the accessor accessibility level.
            set
            {
                test = value;
            }
            // No access modifier is used here.
            get { return test; }
        }
    }
    public class Kid : Parent
    {
        private int test1 = 123;
        public override int TestProperty
        {
            // Use the same accessibility level as in the overridden accessor.
            set { test1 = value / 123; }
            // Cannot use access modifier here.
            get { return 0; }
        }
    }
