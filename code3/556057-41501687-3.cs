    //open workbook
                workBook = oXL.Workbooks.Open(outputfilepath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                //oXL.Visible = false;
                Worksheet sheet = workBook.Sheets["Rapport1"];
               // set Date Format to the sort column 
                Range rg = sheet.Cells[5, colindexM];
                rg.EntireColumn.NumberFormat = "DD/MM/YYYY";
                //M4 is my sort field
                Range oRange = sheet.Range["M4"];
                sheet.EnableAutoFilter = true;
                sheet.AutoFilter.Sort.SortFields.Add(oRange, XlSortOrder.xlAscending);
               
                sheet.AutoFilter.ApplyFilter();    
              
                workBook.Save();
                workBook.Close(true);
                oXL.Quit();
                oXL = null;
                workBook = null;
                GC.Collect(); 
