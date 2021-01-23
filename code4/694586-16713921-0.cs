    foreach (Control c in this.Controls)
    {
        if (c.Name.Equals(checkBoxName))
        {
            (c as CheckBox).Checked = words[1] != "-1";
        }
    }
