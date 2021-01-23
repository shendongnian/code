     public static class DataGridViewRowWExtenstions
        {
            public static T GetObject<T>(this DataGridViewRow Row) where T : new()
            {
                List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
    
                return CreateItemFromRow<T>(Row, properties);
            }
    
            private static T CreateItemFromRow<T>(DataGridViewRow row, List<PropertyInfo> properties) where T : new()
            {
                T item = new T();
                foreach (var property in properties)
                {
                    if (row.DataGridView.Columns.Contains(property.Name))
                    {
                        if (row.Cells[property.Name] != null)
                            property.SetValue(item, row.Cells[property.Name].Value, null);
                    }
                }
                return item;
            }
        }
 
    private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                Company company = selectedRow.GetObject<Company>();
            }
