    Exception ex = null;
    try
    {
        //Do work
    }
    catch (SqlException sqlEx)
    {
        ex = sqlEx;
        if (ex.Number == -2)
        {
           //..
        }
        else
        {
            //..
        }
    }
    catch (Exception generalEx)
    {
      ex = generalEx;
    }
    finally()
    {
      if (ex != null) debugLogGeneralException(ex);
    }
