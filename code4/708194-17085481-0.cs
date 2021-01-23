    PrintDocument pd = new PrintDocument();
    pd.PrinterSettings.PrinterName = "Zebra Printer";
    // Do stuff formatting your document, like drawing strings and images (possibly a zebra?)
    if(pd.PrinterSettings.IsValid) pd.Print();
    else MessageBox.Show("Printer is invalid.");
