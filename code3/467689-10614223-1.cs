    {
      object l_oOutDatatable = null;
      try
      {
        oOutDatable = cmd.MyDatatable(qry, con);
      }
      catch(Exception e)
      {
        log.Message(e.ToString);
      }
      return l_oOutDatatable;
    }
