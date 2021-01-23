    var excel = new Excel.Application();
    
    var workbook = excel.Workbooks.Open(@"C:\Test\Test.xlsx");
    var worksheet = (Excel.Worksheet)workbook.Sheets[1];
    
    Excel.Range range = worksheet.get_Range("A1");
    
    var rangeAsValue = range.Value;
    var rangeAsValue2 = range.Value2;
    
    Console.WriteLine(rangeAsValue);
    Console.WriteLine(rangeAsValue2);
    
    Console.ReadLine();
