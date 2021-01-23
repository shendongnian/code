    OracleClob tempLob = new OracleClob(connection);
    if (paramValue != null)
    {
      byte[] tempbuff = Encoding.Unicode.GetBytes((string)paramValue);
      tempLob.BeginChunkWrite();
      tempLob.Write(tempbuff, 0, tempbuff.Length);
      tempLob.EndChunkWrite();
    }
    parameter.Value = tempLob;
