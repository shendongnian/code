    static void Main(string[] args)
    {
      byte[] byteArray = File.ReadAllBytes("D:\\rptTemplate.xlsx");
    
      using (MemoryStream mem = new MemoryStream())
      {
        mem.Write(byteArray, 0, (int)byteArray.Length);
      
        using (SpreadsheetDocument rptTemplate = SpreadsheetDocument.Open(mem, true))
        {
          foreach (OpenXmlElement oxe in (rptTemplate.WorkbookPart.Workbook.Sheets).ChildElements)
          {
            if(((DocumentFormat.OpenXml.Spreadsheet.Sheet)(oxe)).Name == "ABC")
            {
              ((DocumentFormat.OpenXml.Spreadsheet.Sheet)(oxe)).State = SheetStateValues.Hidden;
               WorkbookView wv = rptTemplate.WorkbookPart.Workbook.BookViews.ChildElements.First<WorkbookView>();
             
               if (wv != null)
               {
                 wv.ActiveTab = GetIndexOfFirstVisibleSheet(rptTemplate.WorkbookPart.Workbook.Sheets);
               }                       
             }
          }
          rptTemplate.WorkbookPart.Workbook.Save();
        }
      }
    }
    private static uint GetIndexOfFirstVisibleSheet(Sheets sheets)
    {
      uint index = 0;
      foreach (Sheet currentSheet in sheets.Descendants<Sheet>())
      {
        if (currentSheet.State == null || currentSheet.State.Value == SheetStateValues.Visible)
        {
          return index;
        }
        index++;
      }
      throw new Exception("No visible sheet found.");
    }
