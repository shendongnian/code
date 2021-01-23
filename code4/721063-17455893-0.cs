    public static string XLGetCellValue(string fileName, string sheetName, string addressName)
    {
       const string worksheetSchema = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
       const string sharedStringSchema = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
    
       string cellValue = null;
    
       //  Retrieve the stream containing the requested
       //  worksheet's info.
       using (SpreadsheetDocument xlDoc = SpreadsheetDocument.Open(fileName, false))
       {
          //  Get the main document part (workbook.xml).
          XmlDocument doc = new XmlDocument();
          doc.Load(xlDoc.WorkbookPart.GetStream());
    
          //  Create a namespace manager, so you can search.
          //  Add a prefix (d) for the default namespace.
          NameTable nt = new NameTable();
          XmlNamespaceManager nsManager = new XmlNamespaceManager(nt);
          nsManager.AddNamespace("d", worksheetSchema);
          nsManager.AddNamespace("s", sharedStringSchema);
    
          string searchString = string.Format("//d:sheet[@name='{0}']", sheetName);
          XmlNode sheetNode = doc.SelectSingleNode(searchString, nsManager);
          if (sheetNode != null)
          {
             //  Get the relId attribute.
              XmlAttribute relationAttribute = sheetNode.Attributes["r:id"];
             if (relationAttribute != null)
             {
                string relId = relationAttribute.Value;
                //  Load the contents of the workbook.
                XmlDocument sheetDoc = new XmlDocument(nt);
                sheetDoc.Load(xlDoc.WorkbookPart.GetPartById(relId).GetStream());
    
                XmlNode cellNode = sheetDoc.SelectSingleNode(string.Format("//d:sheetData/d:row/d:c[@r='{0}']", addressName), nsManager);
                if (cellNode != null)
                {
                   XmlAttribute typeAttr = cellNode.Attributes["t"];
                   string cellType = string.Empty;
                   if (typeAttr != null)
                   {
                      cellType = typeAttr.Value;
                   }
    
                   XmlNode valueNode = cellNode.SelectSingleNode("d:v", nsManager);
                   if (valueNode != null)
                   {
                      cellValue = valueNode.InnerText;
                   }
                   if (cellType == "b")
                   {
                      if (cellValue == "1")
                      {
                         cellValue = "TRUE";
                      }
                      else
                      {
                         cellValue = "FALSE";
                      }
                   }
                   else if (cellType == "s")
                   {
                       if (xlDoc.WorkbookPart.SharedStringTablePart != null)
                       {
                          XmlDocument stringDoc = new XmlDocument(nt);
                          stringDoc.Load(xlDoc.WorkbookPart.SharedStringTablePart.GetStream());
                          //  Add the string schema to the namespace manager.
                          nsManager.AddNamespace("s", sharedStringSchema);
    
                          int requestedString = Convert.ToInt32(cellValue);
                          string strSearch = string.Format("//s:sst/s:si[{0}]", requestedString + 1);
                          XmlNode stringNode = stringDoc.SelectSingleNode(strSearch, nsManager);
                          if (stringNode != null)
                          {
                              cellValue = stringNode.InnerText;
                          }
                       }
                    }
                }
             }
           }
       }
       return cellValue;
    }
