    using (System.Data.SqlClient.SqlDataReader reader = CallStoredProcedure())
    {
        while (reader.Read())
        {
            yield return new ObjectModel.CollectorSummaryItem()
            {
                CollectorID = (int)reader[0],
                Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                Information = reader.IsDBNull(2) ? null : reader.GetString(2)
            };
        }
    }
