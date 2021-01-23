            //Excel Application Object
            Microsoft.Office.Interop.Excel.Application oExcelApp;
            //Get reference to Excel.Application from the ROT.
            if (Process.GetProcessesByName("EXCEL").Count() > 0)
            {
                oExcelApp = (Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                foreach (Microsoft.Office.Interop.Excel.Workbook WB in oExcelApp.Workbooks)
                {
                    //MessageBox.Show(WB.FullName);
                    if (WB.Name == file_name)
                    {
                        WB.Save();
                        WB.Close();
                        //oExcelApp.Quit();
                    }
                }
            }
        }
