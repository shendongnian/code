    class MyData
    {
        [TypeConverter(typeof(FormattedDoubleConverter))]
        [FormattedDoubleFormatString("F3")]
        public double MyProp { get; set; }
    }
