        using System.Runtime.InteropServices;
        Microsoft.Office.Interop.Excel.Application excel;
                try
                {
                    excel = (Microsoft.Office.Interop.Excel)Marshal.GetActiveObject("Excel.Application");
                }
                catch
                {
                     excel = new Microsoft.Office.Interop.Excel.Application();
                }
