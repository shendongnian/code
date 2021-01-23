    public class DisplayedData
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ReadOnly(true)]
        public DataType1 Data1 { get;  }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ReadOnly(true)]
        [DisplayName("Data2")]
        [Browsable(true)]
        public DataType2 Data2 { get;  } //We have Browsable set to true for this
        [DisplayName("Data2")]
        [Browsable(false)]
        public string Data2Error { get;  } //An additional property with Browsable set to false
    }
