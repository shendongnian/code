    using System;
    using System.Windows;
    using System.Windows.Data;
    
    .
    .
    .
    
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var enumType = value.GetType();
        var underlyingType = Enum.GetUnderlyingType(enumType);
        var numericValue = System.Convert.ChangeType(value, underlyingType);
        return numericValue;
    }
