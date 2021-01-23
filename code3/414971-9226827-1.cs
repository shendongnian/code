    protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox headerChkBox = ((CheckBox)gvApproach.HeaderRow.FindControl("headerLevelCheckBox"));
        if (headerChkBox.Checked == true)
        {
            foreach(GridViewRow gvRow in gvApproach.Rows)
            {
                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                rowChkBox.Checked = true;    
            }
        }
        else
        {
            foreach (GridViewRow gvRow in gvApproach.Rows)
            {
                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                rowChkBox.Checked = false;
            }
        }        
    }
