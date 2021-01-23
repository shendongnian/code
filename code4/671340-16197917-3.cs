    private void GetGroupNameList(DropDownList ddl)
        {
            ddl.Items.Clear();
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection con2 = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd1 = new SqlCommand("select distinct Name" +
                            " from MyTable");
    
            cmd1.Connection = con2;
            con2.Open();
    
            ddl.DataSource = cmd1.ExecuteReader();
            ddl.DataTextField = "Name";
            ddl.DataValueField = "Name";
            ddl.DataBind();
            con2.Close();
            ddl.Items.Insert(0, new ListItem("Top 10", "10"));
            ddl.Items.Insert(0, new ListItem("ALL", "ALL"));
            ListItem oListItem = ddl.Items.FindByValue(ViewState["MyFilter"].ToString());
            if(oListItem != null){
                 ddl.ClearSelection();
                 ddl.SelectedValue = oListItem.Value;
            }
        }
