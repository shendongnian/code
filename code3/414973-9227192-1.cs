    public List<string> GetAllSelectedIds()
    {
        List<string> selectedIds= new List<string>();
        for (int i = 0; i < grid.Rows.Count; i++)
        {
            GridViewRow row = grid.Rows[i];
            if (((CheckBox)row.FindControl("rowLevelCheckBox")).Checked)
            {
                string rowLevelCheckBoxStr = ((CheckBox)row.FindControl("rowLevelCheckBox")).ToolTip;
                selectedIds.Add(rowLevelCheckBoxStr);
            }
        }
        return selectedIds;
    }
