    class A
    {
        public B Initialize(B value)
        {
            if (value == null)
            {
                value = new B();
            }
            return value;
        }
    }
