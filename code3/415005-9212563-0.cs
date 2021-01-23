    Application Excel = new Application();
    Workbook workbook = Excel.Workbooks.Add(1);
    Worksheet sheet = workbook.Sheets[1];
    sheet.Cells[1, 1] = DateTime.Now;
    sheet.Cells[2, 1] = DateTime.Now.AddDays(1);
    sheet.Cells[3, 1] = DateTime.Now.AddDays(2);
    sheet.UsedRange.Columns["A:A", Type.Missing].NumberFormat = "MM/dd/yyyy"; 
    workbook.Sheets.Add(sheet);
    // Save the workbook or make it visible
