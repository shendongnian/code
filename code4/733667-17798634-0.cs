    class Numbers
    {
        readonly List<int> num;
        public Numbers()
        {
            // ok - can write to read-only variables in the owner's constructor
            num = new List<int> { 1, 2, 3, 4 };
        }
        void Test()
        {
            // this is fine -- I'm not writing to "num", just changing its state
            num.Clear();
            // compiler error: "a readonly field cannot be assigned to"
            num = new List<int>();
        }
    }
    
