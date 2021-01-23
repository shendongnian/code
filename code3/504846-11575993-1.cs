    public abstract class BaseConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
    public class ExpanderHeaderWidthConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // The actuacl Width of the Expander
            double width = (double)value;
            // Default width difference
            double diff = 25.0;
            if (parameter != null)
            {
                // If the parameter is not null, try to use it as width difference
                Double.TryParse(parameter.ToString(), out diff);
            }
            // If width - diff is less than 0, return double.NaN instead.
            if (width - diff < 0)
            {
                return double.NaN;
            }
            // Return the modified width
            return width - diff;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double width = (double)value;
            double diff = 25.0;
            if (parameter != null)
            {
                Double.TryParse(parameter.ToString(), out diff);
            }
            return width + diff;
        }
    }
