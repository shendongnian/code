    CheckBoxList CheckBoxList1 = ((CheckBoxList)row.FindControl("CheckBoxList1")).Enabled;
    if (CheckBoxList1.SelectedItems.Count > 0)
         Response.Write("Its Checked");
    else
         Response.Write("Not Check");  
