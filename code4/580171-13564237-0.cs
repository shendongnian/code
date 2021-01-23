    private void LoadInventoryCategoryDropDownList()
            {
                SqlConnection con=new SqlConnection(CommonRefference.Constr());
                string query = "Select Id,Name+' ('+Distribution_name+') 'as Name1 from BR_supervisor  ";
                SqlCommand cmd = new SqlCommand(query,con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DropDownList3.DataSource = reader ;
                DropDownList3.DataValueField = "Id"; // Alias Name from Sproc
                DropDownList3.DataTextField = "Name1";   // Alias name from sproc
                DropDownList3.DataBind();
                DropDownList3.Items.Insert(0, new ListItem("Select One", "0")); // Adds items to the DDL
                DropDownList3.Items.Insert(1, new ListItem("All Categories", "-1"));
                SQLDBConn.Close();
            }
