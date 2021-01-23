    class MyClass
    {
        public override string ToString()
        {
            return thing1.PadRight(10) + thing2.PadRight(10);
        }
        public string thing1 { get; set; }
        public string thing2 { get; set; }
    }
