    CheckBox activeCheckBox = sender as CheckBox;
    if(activeCheckBox.Checked)
    {
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            CheckBox checkBox = ((CheckBox)gvr.FindControl("cbGV"));
            checkBox.Checked = checkBox == activeCheckBox;
        }
    }
