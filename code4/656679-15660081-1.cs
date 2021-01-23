    public DataSet getDataSet( string dynSQL )
    {
      var oDS = new DataSet("Command");
      try
      {
        if (!checkConnection()) {
          throw new Exception("No connection to database.");
        }
        using (var oDA = new SqlCeDataAdapter(dynSQL, objCon)) {
          oDA.Fill(oDS);
        }
      } 
      catch (Exception ex)
      {
          Console.WriteLine(ex.Message);
      }
      return( oDS );
    }
