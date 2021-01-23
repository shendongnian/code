    public class Form
    {
        public FieldValue[] Fields { get; set; }
    }
    public class FieldValue
    {
        public Field Field { get; set; }
        [ConditionalRequired("Field")]
        public string Value { get; set; }
    }
    public class Field
    {
        public bool IsRequired { get; set; }
    }
