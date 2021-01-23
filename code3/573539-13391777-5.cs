    private PrintQueue FindPrinter(string printerName)
    {
        var printers = new PrintServer().GetPrintQueues();
        foreach (var printer in printers)
        {
            if (printer.FullName == printerName)
            {
                return printer;
            }
        }
        return LocalPrintServer.GetDefaultPrintQueue();
    }
