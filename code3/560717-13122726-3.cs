    public class Test
    {
        [CsvField(Name = "Text")]
        public string Text { get; set; }
        [CsvField(Name = "SomeDouble")]
        [TypeConverter( typeof( WhiteSpaceToNullableTypeConverter<Double> ) )]
        public double? SomeDouble{ get; set; }
        [CsvField(Name = "MoreText")]
        public string MoreText{ get; set; }
    }
