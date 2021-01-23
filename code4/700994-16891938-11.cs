    public class ResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var resources = value as IEnumerable<ResourceViewModel>;
            if (resources== null) return null;
            
            // Better play safe and serach for the max count of all items
            var columns = resources[0].ResourceStringList.Count;
            var t = new DataTable();
            t.Columns.Add(new DataColumn("ResourceName"));
            for (var c = 0; c < columns; c++)
            {
                // Will create headers "0", "1", "2", etc. for strings
                t.Columns.Add(new DataColumn(c.ToString()));
            }
            foreach (var r in resources)
            {
                var newRow = t.NewRow();
                
                newRow[0] = resources.ResourceName;
                for (var c = 0; c < columns; c++)
                {
                    newRow[c+1] = r.ResourceStringList[c];
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
