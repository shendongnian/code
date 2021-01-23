    public MemoryStream LoadReportData(int rowId)
    {
      MemoryStream stream = new MemoryStream();
      
      using (BinaryWriter writer = new BinaryWriter(stream))
      {
        using (DbConnection connection = db.CreateConnection())
        {
          DbCommand selectCommand = "SELECT CSVData FROM YourTable WHERE Id = @rowId";
          selectCommand.Connection = connection;
          db.AddInParameter(selectCommand, "@rowId", DbType.Int32, rowId);
          connection.Open();
          using (IDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SequentialAccess))
          {
            while (reader.Read())
            {
              int startIndex = 0;
              int bufferSize = 8192;
              byte[] buffer = new byte[bufferSize];
              long retVal = reader.GetBytes(0, startIndex, buffer, 0, bufferSize);
              while (retVal == bufferSize)
              {
                writer.Write(buffer);
                writer.Flush();
                startIndex += bufferSize;
                retVal = reader.GetBytes(0, startIndex, buffer, 0, bufferSize);
              }
              writer.Write(buffer, 0, (int)retVal);
            }
          }
        }
      }
      return stream;
    }
