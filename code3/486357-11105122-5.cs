    List<int> ReadList(IDataReader reader)
    {
        List<int> list = new List<int>();
        int column = reader.GetOrdinal("MyColumn");
    
        while (reader.Read())
        {
            //check for the null value and than add 
            if(!SqlReader.IsDBNull(column))
                 list.Add(reader.GetInt32(column));
        }
    
        return list;
    }
