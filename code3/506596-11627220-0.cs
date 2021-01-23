    while (rdr.Read())
    {
        // ... blah
        using(var myCommand2 = new SqlCommand("InsertHash", myConnection))
        {
            // setup parameters etc
            myCommand2.ExecuteNonQuery();
        }
    }
