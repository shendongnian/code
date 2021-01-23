    public class MatrixToDataViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var array = value as Matrix;
            if (array == null) return null;
                
            //var array = ILMath.rand(3, 5);
    
            var rows = array.Dimensions[0];
            var columns = array.Dimensions[1];
    
            var t = new DataTable();
            for (var c = 0; c < columns; c++)
            {
                t.Columns.Add(new DataColumn(c.ToString()));
            }
    
            for (var r = 0; r < rows; r++)
            {
                var newRow = t.NewRow();
                for (var c = 0; c < columns; c++)
                {
                    var v = array[r, c];
                        
                    // Round if parameter is set
                    if (parameter != null)
                    {
                        int digits;
                        if (int.TryParse(parameter.ToString(), out digits))
                            v = Math.Round(v, digits);
                    }
    
                    newRow[c] = v;
                }
                    
                t.Rows.Add(newRow);
            }
                
    
            return t.DefaultView;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
