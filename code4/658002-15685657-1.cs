    using (var myCon = new SqlConnection(Helper.ConStr))
    using (var selectCommand = new SqlCommand("select * from emptable", myCon))
    {
        myCon.Open();
        using (var dr = selectCommand.ExecuteReader())
        {
            while (dr.Read()) 
            {
                // ...
            }
        }
    }
