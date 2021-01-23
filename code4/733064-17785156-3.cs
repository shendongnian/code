            SqlDataSource2.SelectParameters["num"].DefaultValue = e_num;
           
            if (!IsPostBack)
            {
            GridView1.DataSourceID = "SqlDataSource2";
            GridView1.DataBind();
    
                List<string[]> ids_list = db.return_ids_for_event(Convert.ToInt32(e_num));
    
                foreach (string[] s in ids_list)
                {
                    DropDownList1.Items.Add(new ListItem(s[0], s[1]));
    
                }
            }
