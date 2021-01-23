    var stack= GetItems(SiteId);
    //Add your empty item. 
    RadComboBox1.Items.Add(new RadComboBoxItem("", "0")); 
    //Add all the other items
    foreach(var item in stack)
    {
        RadComboBox1.Items.Add(new RadComboBoxItem(item.Name, item.Id))
    }  
 
    RadComboBox1.DataTextField = "Name"; 
    RadComboBox1.DataValueField = "Id";
