        DropDownList kw1 = (DropDownList)e.Item.FindControl("keyw1");
        DropDownList kw2 = (DropDownList)e.Item.FindControl("keyw2");
        DropDownList kw3 = (DropDownList)e.Item.FindControl("keyw3");
        DropDownList kw4 = (DropDownList)e.Item.FindControl("keyw4");
        DropDownList kw5 = (DropDownList)e.Item.FindControl("keyw5");
        DropDownList kw6 = (DropDownList)e.Item.FindControl("keyw6");
    
        DropDownList[] array = { kw1, kw2, kw3, kw4, kw5, kw6 };
    
        DataView dv = new DataView();
        DataTable dt = new DataTable();    
        dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        dt = dv.ToTable();
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            // dr["column name or column index"] (zero in my case)
            array[i].SelectedItem.Text = dr[0].ToString();
            i++;
        }
