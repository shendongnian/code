    public class FormulaCalculationConverter : IMultiValueConverter
    {
       // this is incomplete formula converter...
       public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
           // strictly assume for 1 + 1
           double retVal = 0;
           if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue
               || values[0] == null || values[1] == null)
           {
               return Binding.DoNothing;
           }
           // apply logic to split formula here
           retVal = System.Convert.ToDouble(values[0]) + System.Convert.ToDouble(values[1]);
           return retVal;
       }
       public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
       {
           throw new NotImplementedException();
       }
    }
