    public class HexStringConverter : IValueConverter
    {
        private string lastValidValue;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ret = null;
            if (value != null && value is string)
            {
                var valueAsString = (string)value;
                var parts = valueAsString.ToCharArray();
                var formatted = parts.Select((p,i)=>(++i)%2==0 ? String.Concat(p.ToString()," ") : p.ToString());
                ret = String.Join(String.Empty,formatted).Trim();
            }
            return ret;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object ret = null;
            if (value != null && value is string)
            {
                var valueAsString = ((string)value).Replace(" ",String.Empty).ToUpper();
                ret = lastValidValue = IsHex(valueAsString) ? valueAsString : lastValidValue;                
            }
            return ret;
        }
        private bool IsHex(string text)
        {
            var reg = new System.Text.RegularExpressions.Regex("^[0-9A-Fa-f]*$");
            return reg.IsMatch(text);
        }
    }
