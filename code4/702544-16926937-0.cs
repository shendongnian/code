    public class ValueStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MyDataContextObectType obj= (MyDataContextObjectType)value;
            var name= obj.Name;
            var key = obj.Key;
            //here you have both Name and Key, build your string and return it
            //if you don't know the type of object in the DataContext, you could get the Key and Name with reflection
            name = name.Replace("$$", " ");
            name = name.Replace("*", ", ");
            name = name.Replace("##", ", ");
    
            return value;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
