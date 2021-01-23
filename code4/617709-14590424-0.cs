    //string command = "SELECT category_id, name FROM CATEGORY ORDER BY name";
    //List<string[]> list = database.Select(command, false);
    // sample data...
    List<string[]> list = new List<string[]> { new string[] { "aaa", "bbb" }, new string[] { "ccc", "ddd" } };
    
    cbxCategory.Items.Clear();
    
    foreach (string[] result in list)
    {
    	cbxCategory.Items.Add(new ComboBoxItem(result[1], result[0]));
    }
    
    ComboBoxItem tmp = cbxCategory.Items.OfType<ComboBoxItem>().Where(x => x.ResultFirst == "bbb").FirstOrDefault();
    if (tmp != null)
    	cbxCategory.SelectedIndex = cbxCategory.Items.IndexOf(tmp);
