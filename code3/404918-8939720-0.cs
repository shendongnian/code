    TextBox name_value = ((TextBox)Gridview1.Rows[0].FindControl("TextBox1"));
    TextBox age_value = ((TextBox)Gridview1.Rows[0].FindControl("TextBox2"));
    DropDownList sex_value = ((DropDownList)Gridview1.Rows[0].FindControl("DropDownList1"));
    DropDownList berth_value = ((DropDownList)Gridview1.Rows[0].FindControl("DropDownList2"));
    
        TextBox1.Text=name_value.Text;
        Dropdownlist1.Text=berth_value.Text;
