    const int MAX_MEMORY_BUFFER = 100000; // To be defined according to you memory limits
    String strConnection;
    String strQuery;
    String strPunchFileNameTemplate;
    
    strConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClockData.accdb";
    strQuery = @"SELECT * FROM ClockPunches";   
    strPunchFileNameTemplate = @"C:\PUNCHES\%READER%.TXT";      
    
    Dictionary<string, StringBuilder> data = new Dictionary<string, StringBuilder>();
    
    using (OleDbConnection ConnObj = new OleDbConnection(strConnection))    
    {
        OleDbCommand CmdObj = new OleDbCommand(strQuery,ConnObj);
        ConnObj.Open();
    
        using (OleDbDataReader ReaderObj = CmdObj.ExecuteReader(CommandBehavior.KeyInfo))   
        {
            while(ReaderObj.Read()) 
            {
                DateTime dtTime = ReaderObj.GetDateTime(ReaderObj.GetOrdinal("PunchTime"));
                Int16 intID = ReaderObj.GetInt16(ReaderObj.GetOrdinal("CardNumber"));
                String strReader = ReaderObj.GetString(ReaderObj.GetOrdinal("Device"));
    
                strReader = GetDeviceFileName(strReader);
    
                bool dataPresent = data.ContainsKey(strReader);
                if (dataPresent == false)   
                {
                    StringBuilder sb = new StringBuilder("EXAMPLE FILE HEADER\r\n");
                    data.Add(strReader, sb);
                }
    
                String outputStr = dtTime.ToString("MM-dd-yyyy HH:mm:ss") + " " + intID.ToString("000000");
                StringBuilder sb = data[strReader];
                sb.AppendLine(outputStr);
                if(sb.Length > MAX_MEMORY_BUFFER)
                {
                    String pathStr = strPunchFileNameTemplate.Replace("%READER%",strReader);
                	using(StreamWriter sw = new StremWriter(pathStr, true) // Append mode
                	{
                        // Write the buffer and set the lenght to zero
                	    sw.WriteLine(sb.ToString());
                	    sb.Length = 0;
                	}
                }
            }
        }
        // Write all the data remaining in memory
        foreach(KeyValuePair<string, StringBuilder> info in data)
        {
        	if(info.Value.Length > 0)
        	{
              String pathStr = strPunchFileNameTemplate.Replace("%READER%",info.Key);
              using(StreamWriter sw = new StremWriter(pathStr, true) // Append mode
              {
                  sw.WriteLine(info.Value.ToString());
              }
        	}
        }
    }
