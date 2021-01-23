    void int DatabaseQuery(string dateInput)
    {
        query = @"
              SELECT rank=Count(*)
              FROM    table
              WHERE table.date Convert(datetime,'" + dateInput + "')"
            DbConnection cn = some Database connection
            cn.Open();
            DbCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            var reason = cmd.ExecuteScalar();
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            return reason.ToInt();
    }
