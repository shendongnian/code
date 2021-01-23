    // Get list for the dropdown (this uses db values)
    var userList = db.Users.ToList();
    
    // Define the Groups
    var group1 = new SelectListGroup { Name = "Administrators" };
    var group2 = new SelectListGroup { Name = "Users" };
    
    // Note - the -1 is needed at the end of this - pre-selected value is determined further down
    // Note .OrderBy() determines the order in which the groups are displayed in the dropdown
    var dropdownList = new SelectList(userList.Select(item => new SelectListItem
    {
        Text = item.Name,
        Value = item.Id,
        // Assign the Group to the item by some appropriate selection method
        Group = item.IsAdministrator ? group1 : group2
    }).OrderBy(a => a.Group.Name).ToList(), "Value", "Text", "Group.Name", -1);
    
    // Assign values to ViewModel
    var viewModel = new PageViewModel
    {
        // Assign the pre-selected dropdown value by appropriate selction method (if needed)
        SelectedDropdownItem = userList.FirstOrDefault(a => a.IsDefault).Id,
        DropdownList =  dropdownList
    };
