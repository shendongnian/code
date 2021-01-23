    protected void chkEHalfDay_CheckedChanged(object sender, EventArgs e)
    {
       CheckBox chkHalfDay = (CheckBox)sender;
       //GridEditFormInsertItem item = (GridEditFormInsertItem)chkHalfDay.NamingContainer;
       GridEditFormInsertItem item = chkHalfDay.NamingContainer as GridEditFormInsertItem;
       if(item == null)
         item = hkHalfDay.NamingContainer as GridEditFormItem;
    
      if (chkHalfDay.Checked == false)
         ((RadComboBox)item.FindControl("rcbHalfDayType")).Enabled = false;
      else
          ((RadComboBox)item.FindControl("rcbHalfDayType")).Enabled = true;
    }
