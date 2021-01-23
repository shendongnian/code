    string Sql = "select company_name from JO.dbo.Comp";
    SqlConnection conn = new SqlConnection(connString);
    SqlCommand cmd = new SqlCommand(Sql, conn);
    cmd.CommandType = CommandType.StoredProcedure;
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    da.Fill(ds);
    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
      comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
