    public DataSet getDataSet( string dynSQL )
    {
      checkConnection();
      SqlCeDataAdapter oDA = new SqlCeDataAdapter( dynSQL, objCon );
      DataSet          oDS = new DataSet( "Command" );
      try
      {
          oDA.Fill( oDS );
      } 
      catch (Exception ex)
      {
          Console.WriteLine(ex.Message);
      }
      return( oDS );
    }
