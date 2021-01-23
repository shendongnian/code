    var values1 = new List<double> { 3, 2, 4, 5 ,6 };
    var values2 = new List<double> { 9, 7, 12 ,15, 17 };
    // Make sure to add a reference to Microsoft.Office.Interop.Excel.dll
    // and use the namespace
    var application = new Application();
    
    var worksheetFunction = application.WorksheetFunction;
    
    var result = worksheetFunction.Correl(values1.ToArray(), values2.ToArray());
    Console.Write(result); // 0.997054485501581
