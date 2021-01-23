    try
    {
      // trying to use DAL
    }
    catch(MyDALException ex)
    {
      // handling
    }
    catch(Exception ex)
    {
       throw new MyBLLException(ex);
    }
