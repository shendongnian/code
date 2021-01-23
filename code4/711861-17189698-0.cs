    for (Int32 i = 0; i < ListView2.Items.Count; i++)
    {
        Int32 a;
        Int32.TryParse(((TextBox)ListView2.Items[i].FindControl("BrankyTextBox")).ToString(), out a);
    
        if (!((CheckBox)ListView2.Items[i].FindControl("UcastCheckBox")).Checked || a > 0)
        {
            RegisterStartupScript("alertBox2", "<script type='text/javascript'>alert('Error');</script>");
        }
    }
