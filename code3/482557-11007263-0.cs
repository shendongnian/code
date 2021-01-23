    public static DataTable GetGridDatasource(string database, string ordnum) {
      using (OleDbConnection con = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source=" + database))
      {
        con.Open();
        OleDbCommand cmd = con.CreateCommand();
        cmd.CommandText = "select * from [Order] where order_num=[OrderNumber]";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("OrderNumber", ordnum);
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
      }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
      Session["OrderNum"] = txtSearch.Text;
      Session["ddl"] = ddlSearch.Text;
      if (Session["ddl"].ToString() == "Order")
      {
        grdSearch.DataSource = GetGridDatasource(Server.MapPath("wsc_database.accdb"), Session["OrderNum"].ToString());
      }
    }
