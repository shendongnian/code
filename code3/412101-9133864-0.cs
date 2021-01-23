    public class CustomDateTimeConverter : ConverterBase
    {
        public CustomDateTimeConverter(string format1, string format2, string format3, string format4)
        {
            _FormatStrings = new string[] { format1, format2, format3, format4} ;
        }
 
        private string[] _FormatStrings;
        public override object StringToField(string from)
        {
            foreach (string formatString in _FormatStrings)
            {
                DateTime dt;
                if (DateTime.TryParseExact(from, formatString, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                    return dt;
            }
            throw new ConvertException(from, typeof(DateTime));
        }
    }
