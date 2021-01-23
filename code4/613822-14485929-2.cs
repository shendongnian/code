    CheckBoxList CheckBoxList1 = ((CheckBoxList)row.FindControl("CheckBoxList1")).Enabled;    
    int i = 0;
    for(i = 0; i < CheckBoxList1.Items.Count; i++)
        if (!CheckBoxList1.Items[i].Checked)
            break;
    if(i == CheckBoxList1.Items.Count)
         Response.Write("Its Checked");
    else
         Response.Write("Not Check");  
