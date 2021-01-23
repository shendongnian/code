    public class CanAddValueConverter : IValueConverter
    {
       private Type _T;
       private DataGrid _dg;
       public void SetValues(DataGrid dg, Type T)
       {
           _T = T;
           _dg = dg;
       }
       public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
       {
           System.Collections.IEnumerable dgIS = value as System.Collections.IEnumerable;
           if (_dg != null && dgIS == _dg.ItemsSource)
           {
               if (_dg.Items.Count > 0)
                   return _dg.Items.Count >= System.Convert.ToInt32(parameter) && _dg.Items[_dg.Items.Count - 1].GetType() != _T;
               else
                   return true;
           }
           else
               return false;
       }
    }
