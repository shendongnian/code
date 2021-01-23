    PrinterInformation info = new PrinterInformation();
    var printers = info.GetPrinters();
    foreach (var printer in printers)
    {
    Response.Write(string.Format("Machine Name : {0} - Printer Name: {1}", Environment.MachineName, printer.DeviceName));
    }
