    catch (System.Data.SqlClient.SqlException sqlEx)
    {
      if (sqlEx.Number == 1205) // Deadlock
         ...
      if (sqlEx.Number == -2) // = TimeOut
         ...
      // etc.
    }
