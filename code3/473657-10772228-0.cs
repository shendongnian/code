    List<CheckBox> checkBox = new List<CheckBox>();
    // Adding checkboxes for testing...
    for (int i = 0; i <= 80; i++)
    {
        var cbox = new CheckBox();
        cbox.Name = "txtChckBx"+ i.ToString();
        checkBox.Add(cbox);
        Controls.Add(cbox);
    
    }
    
    List<CheckBox> checkBoxfound = new List<CheckBox>();
    // loop though all the controls 
    foreach (var item in Controls)
    {
        // filter for checkboxes and name should start with "txtChckBx"
        if (item is CheckBox && ((CheckBox)item).Name.StartsWith("txtChckBx", StringComparison.OrdinalIgnoreCase))
        {
            checkBoxfound.Add((CheckBox)item);
        }
    }
