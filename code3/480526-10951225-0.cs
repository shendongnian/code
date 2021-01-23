    // consider renaming
    public void CheckBox_1()
    {
        var relatedCheckBoxes = GroupBox1.Controls.OfType<CheckBox>();
        foreach (var chk in relatedCheckBoxes)
            chk.Enabled = checkBox1.Checked; // you might want to pass this checkbox as argument instead
    }
