    // using OExcel = Microsoft.Office.Interop.Excel;
    var app = new OEXcel.Application();
    var wbPath = Path.Combine(
        Environment.GetFolderPath(
            Environment.SpecialFolder.MyDocuments), "Book1.xls");
    var wb = app.Workbooks.Open(wbPath);
    var ws = (OEXcel.Worksheet)wb.ActiveSheet;
            
    // there are better ways to do this... 
    // this one's just off the top of my head
    var rngTopLine = ws.get_Range("A1", "C1");
    var rngEndLine = rngTopLine.get_End(OEXcel.XlDirection.xlDown);
    var rngData = ws.get_Range(rngTopLine, rngEndLine);
    var arrayData = (object[,])rngData.Value2;
    var tc = new TestClass();
    
    // since you're enumerating an array, the operation will run much faster
    // than reading the worksheet line by line.
    for (int i = arrayData.GetLowerBound(0); i <= arrayData.GetUpperBound(0); i++)
    {
        tc.LineItems.Add(
            new TestLineItem(arrayData[i, 1], arrayData[i, 2], arrayData[i, 3]));
    }
    var xs = new XmlSerializer(typeof(TestClass));
    var fs = File.Create(Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "Book1.xml"));
    xs.Serialize(fs, tc);
    wb.Close();
    app.Quit();
