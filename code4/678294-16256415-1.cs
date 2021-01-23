    using (SqlConnection myDatabaseConnection = new SqlConnection("DB connection string goes here"))
    {
        myDatabaseConnection.Open();
        using (SqlCommand mySqlCommand = new SqlCommand("select [id], [difference], [date] from [Table1] where [difference] is null", myDatabaseConnection))
        using (SqlDataReader sqlreader = mySqlCommand.ExecuteReader())
        using (SqlCommand myUpdateCmd = new SqlCommand("update [Table1] set [difference] = @difference where [id] = @id", myDatabaseConnection))
        {
            int i;
            myUpdateCmd.Parameters.Add("@id", SqlDbType.Int);
            myUpdateCmd.Parameters.Add("@difference", SqlDbType.Int);
            while (sqlreader.Read())
            {
                i = sqlreader.GetInt32(sqlreader.GetOrdinal("id"));
                double y = GetBusinessDays(sqlreader.GetDateTime(sqlreader.GetOrdinal("date")), DateTime.Now);
                myUpdateCmd.Parameters["@id"].Value = i;
                myUpdateCmd.Parameters["@difference"].Value = (int)y;
                myUpdateCmd.ExecuteNonQuery();
            }
        }
    }
