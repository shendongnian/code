    public class MyControl : Control
    {
        [Category("MyControl")]
        [Description("My Property Description")]
        [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
        public MyObject MyObject { get; set; }
    }
   
   
    public class MyObject
    {
        public string MyProperty { get; set; }
    }
