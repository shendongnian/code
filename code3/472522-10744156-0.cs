    using System.Globalization;
    using System.Text;
    using System.Windows.Data;
    namespace ValidationWPF.DataSources
    {
        class CollectionConverter : IValueConverter
        {
            object Convert(object value, Type targetType,object parameter,CultureInfo culture)
            {
                ObservableCollection<ValidationMessage> messages = (ObservableCollection<ValidationMessage>)value;
                
                var sb = new StringBuilder();
                foreach(var msg in messages)
                {
                    sb.AppendLine(msg.Message);
                }
        
                return sb.ToString();
            }
        
            object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
        }
    }
