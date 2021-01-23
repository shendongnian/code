    public class NullValueConverter : ConverterBase
    {
        public override object StringToField(string stringSource)
        {
            return stringSource;
        }
        public override string FieldToString(object fieldValue)
        {
            // treat string.empty as null
            string result = fieldValue.ToString();
            if (string.IsNullOrWhiteSpace(result))
                return null;
            return result;
        }
    }
