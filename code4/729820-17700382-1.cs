    try
    {
                    // Must be surrounded by try catch to work.
                    // http://naimishpandya.wordpress.com/2010/12/31/hide-power-point-application-window-in-net-office-automation/
                    xlsApp.Visible = true;
                    xlsApp.DisplayAlerts = false;
    }
    catch (Exception e)
    {
                    Console.WriteLine("-------Error hiding the application-------");
                    Console.WriteLine("Occured error might be: " + e.StackTrace);
    }
    Excel.Workbook workbook;
    workbook = xlsApp.Workbooks.Open(configuration.XLSExportedFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                Type.Missing, Type.Missing);
