    public class MyConverter : IValueConverter {
            private ResourceDictionary dictionary;
    
            public MyConverter() {
                if (dictionary == null) {
                    dictionary = new ResourceDictionary();
                    dictionary.Source = new Uri("pack://application:,,,/WpfModifyDifferentView;Component/Resources/Styles.xaml");
                }
            }
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                switch (value.ToString()) {
                    case "ok":
                        return dictionary["myKeyForOkStyle"] as Style;
                    case "hungry":
                        return dictionary["myKeyForHungryStyle"] as Style;
                    case "dead":
                        return dictionary["myKeyForDeadStyle"] as Style;
                    default:
                        return null;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                throw new NotImplementedException();
            }
        }
