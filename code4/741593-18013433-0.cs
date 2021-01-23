    struct MyStruct : ICloneable
    {
        public int MyProperty { get; set; }
    
        public MyStruct Clone()
        {
            return this;
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
    }
