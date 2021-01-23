    using (StreamWriter sw = File.CreateText("ExtractedText.txt"))
    {
        var excelApp = new Excel.Application();
        var workBook = excelApp.Workbooks.Open(thisFile);
        
        foreach (var sheet in workBook.Worksheets)
        {
          foreach (var row in sheet.UsedRange.Rows)
          {
            foreach (var cell in row.Columns)
            {
              sw.Write(cell.Value + " ");
            } 
            sw.WriteLine();
          }
        }
    }
