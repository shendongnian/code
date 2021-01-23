    public class ThumbToFullPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {           
            if (value == null)            
                return value;
                 
            return String.Format("ms-appdata:///local/{0}", value.ToString());
        }
     
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
