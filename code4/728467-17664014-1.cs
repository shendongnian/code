    var selectedIndex = -1;
    
    for(int i = 0; i < catagoryDropDown.Items.Count; i++)
    {
        if(item.Text.ToLower() == "sick leave")
        {
            selectedIndex = i;
            break;
        }
    }
    
    if(selectedIndex > -1)
    {
        catagoryDropDown.SelectedIndex = selectedIndex;
    }
