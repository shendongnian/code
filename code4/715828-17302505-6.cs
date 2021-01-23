    public void SelectAll (Object sender, Eventargs e)
    {
        foreach (var row in grid.Rows)
        {
            var checkBox = (CheckBox)row.FindControl("cbCheckBox");
            checkBox.Checked = cbSelectAll.Checked;          
        }
    }
    public void CheckBoxChanged(Object sender, Eventargs e)
    {
        var isSelectAll;
        
        foreach (var row in grid.Rows)
        {
            var checkBox = (CheckBox)row.FindControl("cbCheckBox");
            isSelectAll = checkBox.Checked;          
        }
    
        cbSelectAll.Checked = isSelectAll;          
    }
