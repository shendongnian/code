    PosExplorer posExplorer = new PosExplorer();
    DeviceInfo receiptPrinterDevice = posExplorer.GetDevice(DeviceType.PosPrinter, "SRP2");
    PosPrinter printer = posExplorer.CreateInstance(receiptPrinterDevice) as PosPrinter;
    
    printer.Open();
    printer.Claim(10000);
    if (printer.Claimed) 
    try {
        printer.DeviceEnabled = true;
        printer.PrintNormal(PrinterStation.Receipt, "test print 1\n");
        printer.DeviceEnabled = false;
    } finally {
        printer.Release();
        printer.Close();
    }
