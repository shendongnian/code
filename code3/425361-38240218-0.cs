    public class DataGridSelectAllBehavior
    {
        public static bool GetValue(DependencyObject obj)
        {
            return (bool)obj.GetValue(ValueProperty);
        }
        public static void SetValue(DependencyObject obj, bool value)
        {
            obj.SetValue(ValueProperty, value);
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(bool), typeof(DataGridSelectAllBehavior), new PropertyMetadata(false,
                (o, e) =>
                {
                    var dg = DataGridSelectAllBehavior.GetDataGrid(o);
                    CheckBox checkBox = o as CheckBox;
                    if (checkBox.IsChecked == true)
                    {
                        dg.SelectAll();
                    }
                    else
                    {
                        dg.UnselectAll();
                    }
                }));
        public static DataGrid GetDataGrid(DependencyObject obj)
        {
            return (DataGrid)obj.GetValue(DataGridProperty);
        }
        public static void SetDataGrid(DependencyObject obj, DataGrid value)
        {
            obj.SetValue(DataGridProperty, value);
        }
        public static readonly DependencyProperty DataGridProperty =
            DependencyProperty.RegisterAttached("DataGrid", typeof(DataGrid), typeof(DataGridSelectAllBehavior), new PropertyMetadata(null));
    }
