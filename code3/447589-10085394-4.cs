    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
            MyObj = new MyClass();
        }
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]     
        public MyClass MyObj { get; set; }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MyClass
    {
        public string Test { get; set; }
    }
