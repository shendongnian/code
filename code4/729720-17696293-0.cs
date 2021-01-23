            // Create an Excel object
            Microsoft.Office.Interop.Excel.Application excel = new  Microsoft.Office.Interop.Excel.Application();
            //Create workbook object
            string str = @"E:\test.xlsx";
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(Filename: str);
            Microsoft.Office.Interop.Excel.Worksheet worksheet1 = workbook.ActiveSheet;
            Microsoft.Office.Interop.Excel.Range range = worksheet1.get_Range("A1","A1");
            Microsoft.Office.Interop.Excel.DropDowns xlDropDowns;
            Microsoft.Office.Interop.Excel.DropDown xlDropDown;
            xlDropDowns = ((Microsoft.Office.Interop.Excel.DropDowns)(workbook.ActiveSheet.DropDowns(Type.Missing)));
            xlDropDown = xlDropDowns.Add((double)range.Left, (double)range.Top, (double)range.Width, (double)range.Height, true);
            xlDropDown.AddItem("item1",1);
            xlDropDown.AddItem("item2", 2);
            //Save the workbook
            workbook.Save();
            //Close the Workbook
            workbook.Close();
            // Finally Quit the Application
            ((Microsoft.Office.Interop.Excel._Application)excel).Quit();
