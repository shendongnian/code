    class A
    {
        public virtual String Value
        {
            get
            {
                return "A";
            }
        }
    }
    class B : A
    {
        public override String Value
        {
            get
            {
                return "B";
            }
        }
    }
