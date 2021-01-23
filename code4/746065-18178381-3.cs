    public class Converter : IMultiValueConverter 
	{
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var formatsource = values[3] as string;  // text value in textboxt formatTemplate
            var re = new Regex(@"%[A-Za-z0-9]+%"); //match any text surrounded by % sign
            var count = 0;
            foreach (var m in re.Matches(formatsource))
            {
               formatsource= re.Replace(formatsource, values[count++] as string, 1);  // replace one match at the time
            }
           
            return formatsource;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
	}
  
