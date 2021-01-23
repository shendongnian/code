    string constr = "...";
    DataSet ds = new DataSet();
    
    using (var con = new SqlConnection(constr))
    {
        string sql = "SELECT TOP 20 * from CHAP1_quiz ORDER BY NEWID()";
        var adapter = new SqlDataAdapter();
        var cmd = new SqlCommand(sql, con);
        adapter.SelectCommand = cmd;
        
        con.Open();
        comms.Fill(ds);  
    }
    
    Repeater1.DataSource = ds;
    Repeater1.DataBind();
