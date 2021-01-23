    private void Test()
    {
        ComboboxItem item = new ComboboxItem();
        item.Text = "Item text1";
        item.PrimaryKey = new object[] { primaryKey1, primaryKey2, primaryKey3, primaryKey4};
    
        comboBox1.Items.Add(item);
    
        comboBox1.SelectedIndex = 0;
    
        MessageBox.Show((comboBox1.SelectedItem as ComboboxItem).Value.ToString());
    }
