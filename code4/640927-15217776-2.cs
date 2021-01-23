    try
    {
      //insertion code
    }
    catch(SqlException ex)
    {
      if(ex.Number == 2627)
        {
         //Violation of primary key. Handle Exception
        }
    }
