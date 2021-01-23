    DataTable tvp = new DataTable();
    tvp.Columns.Add(new DataColumn("ID"));
    
    foreach(var item in tempList)
    { 
        tvp.Rows.Add(item.id); 
    }
    
    using (connObject)
    {
        SqlCommand cmd = new SqlCommand("StoredProcedure", connObject);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter tvparam = cmd.Parameters.AddWithValue("@dept_list", tvp);
        tvparam.SqlDbType = SqlDbType.Structured;
        ...
    }
