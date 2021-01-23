    class FooObject : IObject
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public static explicit operator FooObject(BarObject bar)
        {
            return new FooObject { Name = bar.Name, Value = bar.Value };
        }
    }
    class BarObject : IObject
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public static explicit operator BarObject(FooObject bar)
        {
            return new BarObject { Name = bar.Name, Value = bar.Value };
        }
    }
