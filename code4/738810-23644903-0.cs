    List<DataTable> dtList = new List<DataTable>();
    using (SqlDataReader reader = comm.ExecuteReader())
    {
        while (!reader.IsClosed && reader.Read())
        {
            var dt = new DataTable();
            dt.Load(reader);
            dtList.Add(dt);
        }
    } 
