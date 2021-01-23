    //assume a StreamWriter instance has been created called sw...
    while (rdr.Read())
    {
        for (int index = 0; index < rdr.FieldCount; index++)
        {
            sw.Write(rdr[index].ToString().Replace(',', ' ');
            sw.WriteLine(",");
        }
    }
    
    //flush and close stream
