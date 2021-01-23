    using (FileStream file = new FileStream("c:\\temp\\secure.xlsx", 
           FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
    {
      using (ExcelPackage ep = new ExcelPackage(file, "P@$$W0rd"))
      {
        Console.Out.WriteLine(ep.Workbook.Worksheets[1].Cells["A1"].Value);     
      }
    } 
