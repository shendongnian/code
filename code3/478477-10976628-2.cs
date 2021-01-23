	public class ErrorTypeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var rowObject = values[1] as RowModel;
            var param = values[0].ToString();
            if (rowObject == null) return "";
            if (rowObject.ValidationClass.Any())
            {
                var validationErrors = rowObject.ValidationClass.FirstOrDefault(x => x.SourceColumn == param);
                if (validationErrors != null )
                    return validationErrors.Tag; // Will return "Critical" or "Warning"
            }
            return "";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    } 
