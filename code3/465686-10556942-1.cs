    static void ReadExcelFileSAX(string fileName)
    {
      using (SpreadsheetDocument spreadsheetDocument = 
                                       SpreadsheetDocument.Open(fileName, true))
      {
        WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
        // Iterate through all WorksheetParts
        foreach (WorksheetPart worksheetPart in workbookPart.WorksheetParts)
        {          
          OpenXmlPartReader reader = new OpenXmlPartReader(worksheetPart);
          string text;
          string rowNum;
          while (reader.Read())
          {
            if (reader.ElementType == typeof(Row))
            {
              do
              {
                if (reader.HasAttributes)
                {
                  rowNum = reader.Attributes.First(a => a.LocalName == "r").Value;
                  Console.Write("rowNum: " + rowNum);
                }
              } while (reader.ReadNextSibling()); // Skip to the next row
         
              break; // We just looped through all the rows so no 
                     // need to continue reading the worksheet
            }
            if (reader.ElementType != typeof(Worksheet))
              reader.Skip(); 
          }
          reader.Close();      
        }
      }  
    }
