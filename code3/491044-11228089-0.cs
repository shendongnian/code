            wb.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            while (System.Runtime.InteropServices.Marshal.ReleaseComObject(wb) != 0)
            { }
            excelApp.Quit();
            while (System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp) != 0)
            { }
