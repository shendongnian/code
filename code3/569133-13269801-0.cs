     using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("1232");
                ws.Cells["A1"].AutoFitColumns();
                //ws.Cells[""].AutoFitColumns(20);//overloaded 
                //ws.Cells[""].AutoFitColumns(20,40);//overloaded min and max lengths
            }
