        SqlConnection con = connection string ;
    //new SqlConnection("Data Source=.;uid=sa;pwd=sa123;database=Example1");
    con.Open();
    string sql = "Create Table abcd (";
    foreach (DataColumn column in dt.Columns)
    {
    	sql += "[" + column.ColumnName + "] " + "nvarchar(50)" + ",";
    }
    sql = sql.TrimEnd(new char[] { ',' }) + ")";
    SqlCommand cmd = new SqlCommand(sql, con);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    cmd.ExecuteNonQuery();
    using (var adapter = new SqlDataAdapter("SELECT * FROM abcd", con)) 
    using(var builder = new SqlCommandBuilder(adapter))
    {
    adapter.InsertCommand = builder.GetInsertCommand();
    adapter.Update(dt);
    // adapter.Update(ds.Tables[0]; (Incase u have a data-set)
    }
    con.Close();
