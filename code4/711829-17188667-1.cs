    for (int i = 0; i < ListView2.Items.Count; i++)
    {
        int a;
        Int32.TryParse(((TextBox)ListView2.Items[i].FindControl("BrankyTextBox")).ToString(), out a);
        if (((CheckBox)ListView2.Items[i].FindControl("UcastCheckBox")).Checked ||
             a > 0)
        {
    
        }
    }
