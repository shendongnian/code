     public string GetClients()    
    {         
    string outputxml = string.Empty;         
    Database db = DatabaseFactory.CreateDatabase("MyDatabase");         
    SqlCommand sqlcmd = db.GetSqlStringCommand("SELECT CLIENTID, CLIENTNAME FROM [CLIENTS] FOR XML AUTO, ELEMENTS") as SqlCommand;         
    using (XmlReader reader = db.ExecuteXmlReader(sqlcmd)) 
    {             
      while (reader.Read())             
      {                 
        outputxml = reader.ReadOuterXml();             
      }             
    return outputxml;         
    }
    } 
