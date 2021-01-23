    Workbook theWorkbook = new Workbook();
    theWorkbook.SetCurrentFormat(WorkbookFormat.Excel2007);
    Worksheet theWorkSheet = theWorkbook.Worksheets.Add("Sheet1");
    int iRow = 0;
    int iColumn = 0;
    theWorkSheet.Rows[0].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;
    //Titles
    foreach (DataColumn column in DataTable.Columns)
    {
        theWorkSheet.Rows[iRow].Cells[iColumn].Value = column.ColumnName;
        iColumn++;
    }
    //Values
    foreach (DataRow row in DataTable.Rows)
    {
        iColumn = 0;
        iRow++;
        foreach (var item in row.ItemArray)
        {
            theWorkSheet.Rows[iRow].Cells[iColumn].Value = item.ToString();
            iColumn++;
        }                    
    }
    System.IO.MemoryStream theStream = new System.IO.MemoryStream();
    theWorkbook.Save(theStream);
    byte[] byteArr = theStream.ToArray();
    System.IO.MemoryStream stream1 = new System.IO.MemoryStream(byteArr, true);
    stream1.Write(byteArr, 0, byteArr.Length);
    stream1.Position = 0;
    message.Attachments.Add(new Attachment(stream1, "filename.xlsx"));
