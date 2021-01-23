    private void button1_Click(object sender, EventArgs e)
    {
        object xlApp;
        object xlWbCol;
        object xlWb;
        object xlSheet;
        object xlRangeUsdRng;
        object xlRange;
        object xlWsCol;
        //~~> create new Excel instance
        Type tp;
        tp = Type.GetTypeFromProgID("Excel.Application");
        xlApp = Activator.CreateInstance(tp);
        object[] parameter = new object[1];
        parameter[0] = true;
        xlApp.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, xlApp, parameter);
        xlApp.GetType().InvokeMember("UserControl", BindingFlags.SetProperty, null, xlApp, parameter);
        //~~> Get the xlWb collection
        xlWbCol = xlApp.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, xlApp, null);
        //~~> Create a new xlWb
        xlWb = xlWbCol.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, xlWbCol, null);
        //~~> Get the worksheet collection
        xlWsCol = xlWb.GetType().InvokeMember("WorkSheets", BindingFlags.GetProperty, null, xlApp, null);
        //~~> Create a new workxlSheet
        xlSheet = xlWb.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, xlWsCol, null);
        //~~> Assign cell F5 to xlRange object for testing purpose
        xlRange = xlSheet.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, xlSheet, new object[2] {5, 6 });
        xlRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, xlRange, new object[] { "1-1-2012" });
        //~~> Assign UsedRange
        xlRangeUsdRng = xlSheet.GetType().InvokeMember("UsedRange", BindingFlags.GetProperty, null, xlSheet, null);
        //~~> Get the Columns
        object cols = xlRangeUsdRng.GetType().InvokeMember("EntireColumn", BindingFlags.GetProperty, null, xlRangeUsdRng, null);
        //~~> Autofit
        cols.GetType().InvokeMember("AutoFit", BindingFlags.InvokeMethod, null, cols, null);
    }
