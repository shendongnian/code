    using Access = Microsoft.Office.Interop.Access;
    using System.Runtime.InteropServices;
    static void ExportToCsv(string databasePath, string tableName, string csvFile) {
        Access.Application app = new Access.Application();
        app.OpenCurrentDatabase(databasePath);
        Access.DoCmd doCmd = app.DoCmd;
        doCmd.TransferText(Access.AcTextTransferType.acExportDelim, Type.Missing, tableName, csvFile, true);
        app.CloseCurrentDatabase();
        Marshal.FinalReleaseComObject(doCmd);
        doCmd = null; 
        app.Quit();
        Marshal.FinalReleaseComObject(app);
        app = null;
    }
