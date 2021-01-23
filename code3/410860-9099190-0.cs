    using (SqlCommand command = new SqlCommand(updateSql, db))
    {
        if (StartDate.HasValue())
            command.Parameters.Add("@Date_Started", SqlDbType.DateTime).Value
                = StartDate;
        else
            command.Parameters.Add("@Date_Started", SqlDbType.DateTime).Value 
                = DBNull.Value;
    }
