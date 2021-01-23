     public class ExcelColumnColorConverter : IMultiValueConverter
        {
       public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (!(value[1] == null))
                {
                    var dgrid = (DataGrid)value[0];
                    var colHeader = ((DataGridTextColumn)value[1]).Header.ToString();
    
                    var dView = (System.Data.DataView)dgrid.ItemsSource;
                    var table = dView.Table;
    
                    var rowstateObj = table.Rows[table.Rows.Count - 1][colHeader];
                    Enums.RowState colorValue = (Enums.RowState)Enum.Parse(typeof(Enums.RowState), rowstateObj.ToString());
    
                    switch (colorValue)
                    {
                        case Enums.RowState.HeaderRow:
                            return Brushes.Gainsboro;
                        case Enums.RowState.isIncluded:
                            return Brushes.LightGreen;
                        case Enums.RowState.NotIncluded:
                            return Brushes.LightSalmon;
                        default:
                            return Brushes.Azure;
                    }
                }
                else
                {
                    return null;
                }
    
            }
