    var items = ContactList.GetContactListsByDep(year, main_code); 
    
    foreach(var item in items)
    {
       ddl_contactList.Items.Add(new RadComboBoxItem(item.list_desc, item.list_code));
    }
    
    ddl_contactList.Items.Insert(0, new RadComboBoxItem("NewList", "-1")); 
    ddl_contactList.SelectedIndex = 0; 
