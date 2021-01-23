    //Note untested
    PrintDialog pDialog = new PrintDialog();
    Nullable<Boolean> print = pDialog.ShowDialog();
    if (print == true)
    {
        string value1 = "This is a Test";
        string value2= "Happy Halloween";
        ReportDocument rd = new ReportDocument();
        rd.Load("ReportFile.rpt");
        rd.SetParameter("Parameter1", value1);
        rd.SetParameter("Parameter2", value2);
        rd.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName;
        rd.PrintToPrinter(1, false,0,0);
    }
