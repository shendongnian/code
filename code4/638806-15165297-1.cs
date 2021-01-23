    var checkBoxes = new CheckBox[] {chkBend, chkDryDusty, chkHearing, ...}
    var values = new string[] {"Bend/Stoop", "Dry/Dusty", "Hearing", ...}
    
    var selectedEntries = new List<string>();
    
    for(var i = 0; i < checkBoxes.Length; i++)
    {
        if (checkBoxes[i].Checked)
            selectedEntries.Add(values[i]);
    }
    
    if (TextBox1.Text != "")
        selectedEntries.Add(TextBox1.Text);
    
    LblLimits.Text = string.Join(", ", selectedEntries.ToArray());
