    private void GetGroupNameList(DropDownList DropDownList1)
        {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(New ListItem("ALL", "ALL"));
            DropDownList1.Items.Add(New ListItem("Top 10", "10"));
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection con2 = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd1 = new SqlCommand("select distinct Name" +
                            " from MyTable");
    
            cmd1.Connection = con2;
            con2.Open();
    
            DropDownList1.DataSource = cmd1.ExecuteReader();
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Name";
            DropDownList1.DataBind();
            con2.Close();
            ListItem oListItem = DropDownList1.Items.FindByValue(ViewState["MyFilter"].ToString());
            if(oListItem != null){
                 DropDownList1.ClearSelection();
                 DropDownList1.SelectedValue = oListItem.Value;
            }
        }
