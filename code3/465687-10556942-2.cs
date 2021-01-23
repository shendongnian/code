    static void ReadAllCellValues(string fileName)
    {
      using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
      {
        WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
   
        foreach(WorksheetPart worksheetPart in workbookPart.WorksheetParts)
        {
          OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);
    
          while (reader.Read())
          {
            if (reader.ElementType == typeof(Row))
            {
              reader.ReadFirstChild();
              do
              {
                if (reader.ElementType == typeof(Cell))
                {
                  Cell c = (Cell)reader.LoadCurrentElement();
                  string cellValue;
                  if (c.DataType != null && c.DataType == CellValues.SharedString)
                  {
                    SharedStringItem ssi = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(int.Parse(c.CellValue.InnerText));
                    cellValue = ssi.Text.Text;
                  }
                  else
                  {
                    cellValue = c.CellValue.InnerText;
                  }
                  Console.Out.Write("{0}: {1} ", c.CellReference, cellValue);
                }
              } while (reader.ReadNextSibling());
              Console.Out.WriteLine();
            }            
          }
        }   
      }
    }
