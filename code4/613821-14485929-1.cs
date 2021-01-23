    CheckBoxList CheckBoxList1 = ((CheckBoxList)row.FindControl("CheckBoxList1")).Enabled;
    if (CheckBoxList1.SelectedItems.Count == CheckBoxList1.Items.Count)
         Response.Write("Its Checked");
    else
         Response.Write("Not Check");  
