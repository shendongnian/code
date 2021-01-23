    var ds = new DataSet();
    using (var cn = new SqlConnection())
    using (var cmd = new SqlCommand("myStoredProcedure", cn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        using (var adapter = new SqlDataAdapter(cmd))
        {
            adapter.TableMappings.Add("Table0", "Answers");
            adapter.TableMappings.Add("Table1", "Questions");
            adapter.Fill(ds);
        }
    }
