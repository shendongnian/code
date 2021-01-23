     class NameToBrushConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                Foo item = values[0] as Foo;
                if (item != null)
                {               
                    if (item.Name == "test2")
                        return Brushes.Red;
                    else
                        return Brushes.Black;
                }
    
                return Brushes.Black;
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
