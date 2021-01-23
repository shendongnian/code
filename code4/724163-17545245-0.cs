    var source = GetSourceCollection();
    var query = source;
    if(FirstNameCheckbox.Checked)
        query = query.Where(x => x.FirstName.Contains(FirstNameTextBox);
    if(LirstNameCheckbox.Checked)
        query = query.Where(x => x.LirstName.Contains(LirstNameTextBox);
    // (...)
    // execution is right here, when ToList is called
    var results = query.ToList();
