        public void Proc()
        {
            var ints = new [] { 1, 2, 3, 4 };
            FunctionChangingByReference(ref ints[1]);
        }
        public void FunctionChangingByReference(ref int x)
        {
            x = 500;
        }
