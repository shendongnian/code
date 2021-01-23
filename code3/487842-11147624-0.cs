    internal sealed class CenterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double canvasWidth = System.Convert.ToDouble(values[0]);
            double canvasHeight = System.Convert.ToDouble(values[1]);
            double controlWidth = System.Convert.ToDouble(values[2]);
            double controlHeight = System.Convert.ToDouble(values[3]);
            switch ((string)parameter)
            {
                case "top":
                    return (canvasHeight - controlHeight) / 2;
                case "bottom":
                    return (canvasHeight + controlHeight) / 2;
                case "left":
                    return (canvasWidth - controlWidth) / 2;
                case "right":
                    return (canvasWidth + controlWidth) / 2;
                default:
                    return 0;
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
