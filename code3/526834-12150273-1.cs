    using(reader)
    {
          //Obtain the first row of data.
          reader.Read();
          //Obtain the LOBs (all 3 varieties).
          OracleLob BLOB = reader.GetOracleLob(1);
          ...
    
          //Example - Reading binary data (in chunks).
          byte[] buffer = new byte[4096];
          while((actual = BLOB.Read(buffer, 0, buffer.Length)) >0)
             Console.WriteLine(BLOB.LobType + 
                ".Read(" + buffer + ", " + buffer.Length + ") => " + actual);
    
          ...
    }
