        private static void printLables(byte[] LabelFile)
        {
        string s = System.Text.ASCIIEncoding.ASCII.GetString(LabelFile);
        PrintDialog pd = new PrintDialog();
        pd.PrinterSettings = new PrinterSettings();
        pd.PrinterSettings.PrinterName = "Your Printer Name";
        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
        }
