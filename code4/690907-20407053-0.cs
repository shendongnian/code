    [TypeConverterAttribute(typeof(MyClass)),
    DescriptionAttribute("Expand to see the settings.")]
    public class MyClass: MyClassConverter
    {
        public string Name
        {
            get { return _name;  }
            set { _name = value; }
        }
        public int IID
        {
            get { return _iid; }
            set { if ((64 > value) && (value >= 0)) _iid = value; }
        }
        private string _name;
        private int    _iid;
    }
    [TypeConverter(typeof(MyClassCollectionConverter))]
    public class MyClassCollection : CollectionBase, ICustomTypeDescriptor
    {
        // See the article for code for the overrides (for CollectionBase) and implementation (for ICustomTypeDescriptor)
    }
