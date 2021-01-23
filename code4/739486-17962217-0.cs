    string Sql = "select Company_ID,company_name from JO.dbo.Comp";
    SqlConnection conn = new SqlConnection(connString);
    SqlCommand cmd = new SqlCommand(Sql, conn);
    cmd.CommandType = CommandType.Text;
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    da.Fill(ds);
    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    {
      
         comboBox1.DataSource = ds.Tables[0];
         comboBox1.DataTextField = "company_name";
         comboBox1.DataValueField = "Company_ID";
         comboBox1.DataBind();
         comboBox1.Items.Insert(0, new ListItem("--Select--", "0"));
    }
