    public class MyDataModel
    {
        public enum SampleEnum { EnumPosition1, EnumPosition2, EnumPosition3 }
        [JsonProperty(Required = Required.Always)]
        [RegularExpression(@"^[0-9]+$")]
        public string PatternTest { get; set; }
        [JsonProperty(Required = Required.Always)]
        [MaxLength(3)]
        public string MaxLength3 { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        [EnumDataType(typeof(SampleEnum))]
        public string EnumProperty { get; set; }
    }
