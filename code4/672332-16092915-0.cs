    object MyGetValue(int i)
    {
     
      if(rdr.GetFieldType(i) == typof(DateTime))
      {
        try{
           return rdr.GetValue(i);
        }
        catch(ArgumentOutOfRangeException)
        {
         return null;
        }
      }
      return rdr.GetValue(i); 
    }
