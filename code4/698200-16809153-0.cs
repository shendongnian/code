    public class MyModel
    {
        public int MyModelID            { get; set; }
        public string FixedProperty1    { get; set; }
        public string FixedProperty2    { get; set; }
        // This is a navigation property for all your custom properties
        public virtual ICollection<CustomProperty> CustomProperties  { get; set; }
    }
    public class CustomProperty
    {
        public int CustomPropertyID      { get; set; }
        // This is the name of custom field
        public string PropertyName       { get; set; }
        // And this is its value
        public string PropertyValue      { get; set; }
        // FK reference and navigation property to your main table
        public int MyModelID             { get; set; }
        public virtual MyModel MyModel   { get; set; }
    }
