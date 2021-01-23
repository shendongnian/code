     public static List<string> ProcessXMLDoc()
     {
          XmlDocument xDoc = new XmlDocument();
          xDoc.Load("http://www.floatrates.com/daily/USD.xml");
          List<string> xmlList = new List<string>();
          StringReader sr = new StringReader(xDoc.OuterXml);
    
          DataSet ds = new DataSet();
          ds.ReadXml(sr);
    
          foreach (DataRow row in ds.Tables[0].Rows)
          {
               if (!string.IsNullOrWhiteSpace(row[0].ToString()))
               {
                    xmlList.Add(row[0].ToString());
               }
          }
    
          return xmlList;
      }
