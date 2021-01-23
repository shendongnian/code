    class A
    {
        public virtual string Print()
        {
            return "Called from A";
        }
    }
    class B : A
    {
        public override string  Print()
        {
            return "Called from B";
        }
    }
