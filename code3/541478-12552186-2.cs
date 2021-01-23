    Dictionary<string, DataTable> dictionary1 = new Dictionary<string, DataTable>();
    foreach (DataTable table in ds.Tables)
    {
        dictionary1.Add(table.TableName, table);
    }
    comboBox1.ItemsSource = dictionary1;
    comboBox1.DisplayMemberPath = "Key";
    comboBox1.SelectedValuePath = "Value"; 
