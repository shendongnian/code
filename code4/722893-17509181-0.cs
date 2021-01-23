    int ordinal_so_type=reader.GetOrdinal("so_type");
    //...
    while(reader.Read()==true)
    {
      //reading other columns here
      if (reader.IsDBNull(ordinal_so_type)==false)
      {
        s.type=reader.GetInt32(ordinal_so_type);
      }
      else
      {
        //do whatever you like if the so_type column is null
      }
    }
