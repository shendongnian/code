    public class CustomDateConverter : ConverterBase
    {
        public override object StringToField(string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue) || stringValue == "00000000")
            {
                return null;
            }
            return Convert.ToDateTime(stringValue);
        }
        public override string FieldToString(object fieldValue)
        {
            return fieldValue == null ? "00000000" : ((DateTime)fieldValue).ToString("MMddyyyy");
        }
    }
    [FieldConverter(typeof(CustomDateConverter))]
    public DateTime? MyDate;
