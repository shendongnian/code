    using (SqlDataReader sqlDR = sqlComm.ExecuteReader(CommandBehavior.SingleRow))
    {
        if (sqlDR.Read())
        {
            //Creating the new object to be returned by using the data from the database.
            return new Customer
            {
                CustomerID = Convert.ToInt32(sqlDR["CustomerID"])
            };
        }
        else
            return null;
    }
