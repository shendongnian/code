         //open workbook
        workBook = oXL.Workbooks.Open(outputfilepath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        //oXL.Visible = false;
        Worksheet sheet = workBook.Sheets["Rapport1"];
        // set Date Format to the sort column 
        Range rg = sheet.Cells[5, colindexM];
        rg.EntireColumn.NumberFormat = "DD/MM/YYYY";
        
        sheet.EnableAutoFilter = true;
      sheet.AutoFilter.Sort.SortFields.Add(rg, XlSortOn.xlSortOnValues, XlSortOrder.xlAscending,"", XlSortDataOption.xlSortTextAsNumbers );        
        sheet.AutoFilter.ApplyFilter();    
                  
        workBook.Save();
      
        oXL.Quit();
       
