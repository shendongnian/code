     string items = "";
        if (RadComboBox1.CheckedItems.Count>0)
        {
            foreach (RadComboBoxItem item in RadComboBox1.CheckedItems)
                items += item.Text+ ",";
        }
        Response.Write(items);``
    
        
