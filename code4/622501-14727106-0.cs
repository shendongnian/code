    public DataRow AccessFirstRow(DataTable dt)
    {
      try
      {
        return dt.Rows[0];
      }
      catch (Exception e)
      {
        //There isn't a first row or dt is null
      }
    }
