        DataSet ds = GetAllCategory();
        if (ds.Tables.Count > 0)
        {
            DropDownList1.DataTextField = "identifier";
            DropDownList1.DataValueField = "OS_ID"; //Change field to one you want.
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataBind();
        }
       if(DropDownList1.Items.Count > 0)
       { 
           DropDownList1.SelectedIndex = 0;
           DropDownList1_SelectedIndexChanged(this,null);
       }
