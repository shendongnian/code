    while (reader.Read())
    {
        //Use the object intializer syntax to create a mahasiswaData object inline for simplicity
        gridData.Add(new mahasiswaData()
        {
            Nama = reader.GetString(reader.GetOrdinal("Name")),
            Umur = reader.GetInt32(reader.GetOrdinal("Age"))
        });
    
    }
