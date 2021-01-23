    using(SqlConnection conn = new SqlConnection(connectionString)) 
    {
        conn.Open();
        //Use connection here
        using(SqlCommand cmd = conn.CreateCommand())
        {
            //...
        }
    }
