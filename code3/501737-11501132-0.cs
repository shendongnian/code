        class ByteArrayToString : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    var listOfBytes = value as Byte[];
                    string output ="";
                    output = listOfBytes.Aggregate(output, (current, elemt) => current + elemt.ToString());
                    return output;
                }
    
                return "";
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return DependencyProperty.UnsetValue;
            }
        }
