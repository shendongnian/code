    public class FourLetterGroupConverter : IValueConverter
    {     
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var toConvert = (string)value;
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < toConvert.Length; i++)
            {
                sb.Append(toConvert[i]);
                if(i != 0 && i%4 ==0)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
