      var ep = new ExcelPackage(new FileInfo(excelFile));
      var ws = ep.Workbook.Worksheets["Sheet1"];
      var domains = new List<string>();
      for (int rw = 1; rw <= ws.Dimension.End.Row; rw++)
      {
        if (ws.Cells[rw, 1].Value != null)
         domains.Add(ws.Cells[rw, 1].Value.ToString());
      }
