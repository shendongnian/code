    for (int i = 0; i < ListView2.Items.Count; i++)
    {
        if (((CheckBox)ListView2.Items[i].FindControl("UcastCheckBox")).Checked ||
            int.Parse(((TextBox)ListView2.Items[i].FindControl("BrankyTextBox")).ToString()) > 0)
        {
    
        }
    }
