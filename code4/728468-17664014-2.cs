    var selectedIndex = -1;
    
    for(int i = 0; i < catagoryDropDown.Items.Count; i++)
    {
        if(catagoryDropDown.Items[i].Text.ToLower() == "sick leave")
        {
            selectedIndex = i;
            break;
        }
    }
    
    if(selectedIndex > -1)
    {
        catagoryDropDown.SelectedIndex = selectedIndex;
    }
