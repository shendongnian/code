    using System.Reflection;
    using System.Text;
    //***    
    
    
    public void ToCSV<T>(IEnumerable<T> items, string filePath)
    {
        var dataTable = new DataTable(typeof(T).Name);
        PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var prop in props)
            dataTable.Columns.Add(prop.Name, prop.PropertyType);
    
        foreach (var item in items)
        {
            var values = new object[props.Length];
            for (var i = 0; i < props.Length; i++)
            {
                values[i] = props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
    
        StringBuilder fileContent = new StringBuilder();
        foreach (var col in dataTable.Columns)
            fileContent.Append(col.ToString() + ",");
    
        fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
    
        foreach (DataRow dr in dataTable.Rows)
        {
            foreach (var column in dr.ItemArray)
                fileContent.Append("\"" + column.ToString() + "\",");
    
            fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
        }
    
        try
        {
            System.IO.File.WriteAllText(filePath, fileContent.ToString());
        }
        catch (Exception)
        {
    
            throw;
        }
    }
