    public class Container
    {
        [TypeConverter(typeof(MyIdTypeConverter))]
        public MyId Custom { get; set; }                
    }
