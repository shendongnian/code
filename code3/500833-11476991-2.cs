    Reader = command.ExecuteReader();
    int charguid = 0;
    if(Reader.Read())
    {
       if(Reader[0] != DBNull.Value)
       {
           if(int.TryParse(Reader[0].ToString(), out charguid))
           {
            //value read and is an integer!
           }
       }
    }
    return charguid;
