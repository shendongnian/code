    [DefaultPropertyAttribute("Property1")]
    public class Chart
    {
        [CategoryAttribute("My Properties"),
         DescriptionAttribute("My demo property int"),
         DefaultValueAttribute(10)]
        public int Property1 { get; set; }
        [Browsable(false)]
        public object Property2 { get; set; }
        [CategoryAttribute("My Properties"),
         DescriptionAttribute("My demo property string"),
         DefaultValueAttribute("Hello World!")]
        public string Property3 { get; set; }
        // etc.
    }
