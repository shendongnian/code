    <Converters:StringFormatConverter x:Key="StringFormatConverter" />
    {Binding 
         RelativeSource={RelativeSource TemplatedParent}, 
         Path=Minutes, 
         StringFormatConverter={StaticResource StringFormatConverter},
         ConverterParameter=D2
    }
    public class StringFormatConverter : IValueConverter
    {
        #region Implementation of IValueConverter
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var fmt = string.Format("{{0:{0}}}", parameter);
            return string.Format(fmt, value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
