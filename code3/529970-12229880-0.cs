    private void print_Click(object sender, System.EventArgs e)
    {
        string s = "Hello"; // device-dependent string, need a FormFeed?
        
        // Allow the user to select a printer.
        PrintDialog pd  = new PrintDialog();
        pd.PrinterSettings = new PrinterSettings();
        if( DialogResult.OK == pd.ShowDialog(this) )
        {
            // Send a printer-specific to the printer.
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
        }
    }
