    class Test
    {
        public readonly int IntValue;
        public readonly string StringValue;
        private Test()
        {
            // Do common initialisation.
        }
        public Test(int intValue): this()
        {
            IntValue = intValue;
        }
        public Test(string stringValue): this()
        {
            StringValue = stringValue;
        }
    }
