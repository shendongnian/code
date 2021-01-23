    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter == null)
            {
                return value;
            }
     
            string group = (string) parameter;
            string color = "";
    
            if(group.equals("Group 1"))
            {
                color = "Red";
            }else if(group.equals("Group 2"))
            {
                color = "Green";
            }else{
                color = "Blue"
            }
    
            return color;
        }
     
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
