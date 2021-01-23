    //Use RadComboBoxItem.Selected
    RadComboBoxItem item = RadComboBox1.FindItemByText("Item 2");
    item.Selected = true;
    
    //Use RadComboBox.SelectedIndex
    int index = RadComboBox1.FindItemIndexByValue("2");
    RadComboBox1.SelectedIndex = index;
    
    //You can also use the SelectedValue property.
    RadComboBox1.SelectedValue = value;
