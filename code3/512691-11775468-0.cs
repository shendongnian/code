                Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
                App.Visible = false;
                App.WindowState = Excel.XlWindowState.xlMinimized;
                App.ShowStartupDialog = false;
                Excel.Workbook WorkBook = App.Workbooks.Open(File, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
