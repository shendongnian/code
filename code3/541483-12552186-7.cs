    Dictionary<string, DataTable> dictionary = new Dictionary<string, DataTable>();
    foreach (DataTable table in ds.Tables)
    {
        dictionary.Add(table.TableName, table);
    }
    
    comboBox1.DataSource = new BindingSource(dictionary, null);
    comboBox1.DisplayMember = "Key";
    comboBox1.ValueMember = "Value"; 
