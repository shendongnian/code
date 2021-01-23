    using System.Drawing.Printing;
    using Excel = Microsoft.Office.Interop.Excel;
	
    Excel.Application application = new Excel.Application();
    Excel.Workbook workbook = application.Workbooks.Add();
    Excel.Worksheet worksheet = workbook.Sheets[1];
    
    var printers = PrinterSettings.InstalledPrinters;
    
    Console.WriteLine("Select printer (type the number):");
    Console.WriteLine();
    
    for (int i = 0; i < printers.Count; i++)
    {
        Console.WriteLine("{0} - {1}", i, printers[i]);
    }
    
    int selection = Convert.ToInt32(Console.ReadLine());
    
    application.ActivePrinter = printers[selection];
    worksheet.PrintPreview();
