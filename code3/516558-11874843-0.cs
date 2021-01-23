       String
           connectionString = "...",
           sqlStatement = "select * from Test",
           output = "";
        DataSet dataSet = new DataSet("Contents");
        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlStatement, connectionString)){
            adapter.Fill(dataSet, "Test");}
        using (StringWriter stringWriter = new StringWriter()) { 
          dataSet.WriteXml(new XmlTextWriter(stringWriter));
          output = stringWriter.ToString();
        };
        XmlDocument document = new XmlDocument();
        document.LoadXml(output);
