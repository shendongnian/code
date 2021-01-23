    while (reader.Read()) {
    LoadData b = new LoadData();
    
    b.filename = reader.GetString(1);
    b.date = reader.GetSqlDateTime(3).ToString();
    b.filetype = reader.GetString(4);
    b.height = (Int32)reader.GetSqlInt32(5);
    b.width = (Int32)reader.GetSqlInt32(6);
    b.uploadGroup = reader.GetString(7);
    b.title = reader.GetString(8);
    b.uniqueID = reader.GetString(9);
    b.uploader = reader.GetString(10);
    b.uniqueIDnoExt = reader.GetString(12);
    
    info.Add(b);
    }
