    void CopyRange(CellRangeAddress range, ISheet sourceSheet, ISheet destinationSheet)
    {
      for (var rowNum = range.FirstRow; rowNum <= range.LastRow; rowNum++)
      {
        IRow sourceRow = sourceSheet.GetRow(rowNum);
    
        if (destinationSheet.GetRow(rowNum)==null)
          destinationSheet.CreateRow(rowNum);
    
        if (sourceRow != null)
        {
          IRow destinationRow = destinationSheet.GetRow(rowNum);
    
          for (var col = range.FirstColumn; col < sourceRow.LastCellNum && col<=range.LastColumn; col++)
          {
            destinationRow.CreateCell(col);
            CopyCell(sourceRow.GetCell(col), destinationRow.GetCell(col));
          }
        }
      }
    }
    
    void CopyColumn(string column, ISheet sourceSheet, ISheet destinationSheet)
    {
      int columnNum = CellReference.ConvertColStringToIndex(column);
      var range = new CellRangeAddress(0, sourceSheet.LastRowNum, columnNum, columnNum);
      CopyRange(range, sourceSheet, destinationSheet);
    }
    void CopyCell(ICell source, ICell destination)
    {
      if (destination != null && source != null)
      {
        //you can comment these out if you don't want to copy the style ...
        destination.CellComment = source.CellComment;
        destination.CellStyle = source.CellStyle;
        destination.Hyperlink = source.Hyperlink;
    
        switch (source.CellType)
        {
            case CellType.Formula:
                destination.CellFormula = source.CellFormula; break;
            case CellType.Numeric:
                destination.SetCellValue(source.NumericCellValue); break;
            case CellType.String:
                destination.SetCellValue(source.StringCellValue); break;
        }
      }
    }
    IWorkbook OpenWorkbook(string path)
    {
      IWorkbook workbook;
      using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
      {
        workbook = WorkbookFactory.Create(fileStream);
      }
      return workbook;
    }
    
    void SaveWorkbook(IWorkbook workbook, string path)
    {
      using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        workbook.Write(fileStream);
      }
    }
