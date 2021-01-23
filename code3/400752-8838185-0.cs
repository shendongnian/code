    DocInfo = PropertySetFactory.CreateDocumentSummaryInformation();
    DocInfo.Company = "Dillie-O Digital";
    Workbook.DocumentSummaryInformation = DocInfo;
    
    SummaryInfo = PropertySetFactory.CreateSummaryInformation();
    SummaryInfo.Subject = "Soup to Nuts GridView Export Example";
    Workbook.SummaryInformation = SummaryInfo;
    
    DataSheet = Workbook.CreateSheet("Employees");
    
    for(int i = 0; i <= GridData.Rows.Count - 1; i++)
    {
       CurrRow = DataSheet.CreateRow(i);
    
       for(int j = 0; j <= GridData.Rows[i].Cells.Count - 1; j++)
       {
          if(!IgnoreColumns.Contains(j))
          {
             CurrCell = CurrRow.CreateCell(i);
             CurrCell.SetCellValue(GridData.Rows[i].Cells[j].Text);
          }
       }
    }
    
    ResultStream = new FileStream(EndPath, FileMode.Create);
    Workbook.Write(ResultStream);
    ResultStream.Close();
