    using (SqlCeDataReader myReader = cmd.ExecuteReader(CommandBehavior.SingleRow))
    {
        if (myReader.HasRows)
        {
            while (myReader.Read())
            {
                var itemID = myReader.GetString(0);
                var packSize = myReader.GetString(1);
                // ... use read values 
            }
        }
    }
