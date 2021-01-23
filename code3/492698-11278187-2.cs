    using System;
    using System.Globalization;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfApplication1
    {
        public class ConfigToDynamicGridViewConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var config = value as ColumnConfig;
                if (config != null)
                {
                    var grdiView = new GridView();
                    foreach (var column in config.Columns)
                    {
                        var binding = new Binding(column.DataField);
                        grdiView.Columns.Add(new GridViewColumn {Header = column.Header, DisplayMemberBinding = binding});
                    }
                    return grdiView;
                }
                return Binding.DoNothing;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
    }
