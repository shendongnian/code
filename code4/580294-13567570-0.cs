    using(var conn = new SqlConnection(connectionString))
    using(var cmd = new SqlCommand(procName, conn))
    using(var adapt = new SqlDataAdapter(cmd)) {
        cmd.CommandType = CommandType.StoredProcedure; // <<< this was missing
        SqlParameter p = new SqlParameter("@ReportKey", this.ReportKey);
        p.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(p);
        DataTable table = new DataTable();
        adapt.Fill(table);     
        return table;
    }
