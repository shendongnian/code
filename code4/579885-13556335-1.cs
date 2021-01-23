    public class MyControl : Control
    {
        public MyControl()
        {
            MyObject = new MyObject();
        }
        [Category("MyControl")]
        [Description("My Property Description")]
        [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
        public MyObject MyObject { get; set; }
    }
   
   
    public class MyObject
    {
        public string MyProperty { get; set; }
    }
