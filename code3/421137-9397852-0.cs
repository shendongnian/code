    var settings = new Settings();
    settings.Subcategory1 = new SubCategory1(){Property1 = "P1", Property2 = "P2"};
    settings.Subcategory2 = new SubCategory2(){Property3="P3"};
    grid.SelectedObject = settings;
...
    
    public class Settings
    {
        [Category("Category1")]
        public SubCategory1 Subcategory1 { get; set; }
        [Category("Category1")]
        public SubCategory2 Subcategory2 { get; set; }
    }
    [TypeConverter(typeof (ExpandableObjectConverter))]
    public class SubCategory1
    {
        public String Property1 { get; set; }
        public String Property2 { get; set; }
        public override string ToString()
        {
            return String.Empty;
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SubCategory2
    {
        public String Property3 { get; set; }
        public override string ToString()
        {
            return String.Empty;
        }
    }
