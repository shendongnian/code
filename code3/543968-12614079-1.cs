    using Microsoft.Office.Interop.Excel;
    Type type = SampleAssembly.GetType("Microsoft.Office.Interop.Excel.ApplicationClass");
    var application = Activator.CreateInstance(type);
    var workbook = application.Workbooks.Open(fileName);
    var worksheet = workbook.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet;
