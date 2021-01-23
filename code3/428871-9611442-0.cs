    Excel.Application xlApp = new Excel.Application();
    string filename = xlApp.StartupPath + "\\personal.xls";
    xlApp.Workbooks.Open(filename, 0, false, 5, Missing.Value, Missing.Value, false,
        Missing.Value, Missing.Value, Missing.Value, false, Missing.Value, false,
        true, false);
