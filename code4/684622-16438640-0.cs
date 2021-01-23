    using (SqlDataSource sqlds = new SqlDataSource(ConnectionString(), SelectCommand()))
    {
    	drop1.DataSource = sqlds;
    	drop1.DataTextField = "UserName";
    	drop1.DataBind();// insert after DataBind
    	drop1.Items.Insert(0, new ListItem(" Select ", ""));
    }
