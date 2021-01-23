    class MyData
    {
        [TypeConverter(typeof(CustomNumberTypeConverter))]
        public int MyProp { get; set; }
    }
