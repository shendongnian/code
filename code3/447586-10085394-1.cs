    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MyClass
    {
        // Some staff
    }
    public class MyControl : UserControl
    {
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]     
        public MyClass MyObj { get; set; }
    }
