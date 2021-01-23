    // Obtain your list of ids to send, this is just an example call to a helper utility function
    int[] employeeIds = GetEmployeeIds();
    DataTable tvp = new DataTable();
    tvp.Columns.Add(new DataColumn("ID", typeof(int)));
    // populate DataTable from your List here
    foreach(var id in employeeIds)
        tvp.Rows.Add(id);
    
    using (conn)
    {
        SqlCommand cmd = new SqlCommand("dbo.DoSomethingWithEmployees", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter tvparam = cmd.Parameters.AddWithValue("@List", tvp);
        // these next lines are important to map the C# DataTable object to the correct SQL User Defined Type
        tvparam.SqlDbType = SqlDbType.Structured;
        tvparam.TypeName = "dbo.IDList";
        // execute query, consume results, etc. here
    }
