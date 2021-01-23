    public class YourAppendingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, 
          System.Globalization.CultureInfo culture){
           StringBuilder sb = new StringBuilder(values[0].ToString());
           sb.AppendLine("Tasks:");
           foreach (var task in (Dictionary<string,string>)values[1]){
             sb.AppendLine(string.Format("{0}: {1}", task.Key, task.Value));
           }
           return sb.ToString();
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, 
          System.Globalization.CultureInfo culture){
            throw new NotSupportedException();
        }
