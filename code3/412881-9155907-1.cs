    using (ExcelPackage xlPackage = new ExcelPackage(existingFile))
    {
      // get the first worksheet in the workbook
      ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
      int iCol = 2;  // the column to read
    
      // output the data in column 2
      for (int iRow = 1; iRow < 6; iRow++)
        Console.WriteLine("Cell({0},{1}).Value={2}", iRow, iCol, 
          worksheet.Cell(iRow, iCol).Value);
    
      // output the formula in row 6
      Console.WriteLine("Cell({0},{1}).Formula={2}", 6, iCol, 
        worksheet.Cell(6, iCol).Formula);
    			
    } // the using statement calls Dispose() which closes the package.
