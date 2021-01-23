    PrinterSettings ps = new PrinterSettings();
    var maxResolution = ps.PrinterResolutions.OfType<PrinterResolution>()
                                             .OrderByDescending(r => r.X)
                                             .ThenByDescending(r => r.Y)
                                             .First();
    MessageBox.Show(String.Format("{0}x{1}", maxResolution.X, maxResolution.Y));
