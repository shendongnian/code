    public static Int32 ToInt32(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    public static object Get(this DataGridViewRow row,string columnName)
        {
            foreach (DataGridViewCell item in row.Cells)
            {
                if (item.OwningColumn.DataPropertyName.Equals(columnName))
                {
                    return item.Value;
                }
            }
            return null;
        }
