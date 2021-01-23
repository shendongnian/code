    public class EnumToBoolConverter : BaseConverterMarkupExtension<object, bool>
        {
            public override bool Convert(object value, Type targetType, object parameter)
            {
                if (value == null)
                    return false;
    
                return value.Equals(Enum.Parse(value.GetType(), (string)parameter, true));
            }
    
            public override object ConvertBack(bool value, Type targetType, object parameter)
            {
                return value.Equals(false) ? DependencyProperty.UnsetValue : parameter;
            }
        }
