    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
            try
            {
                string filePath = ("confirm//") + FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath(filePath));
    
                Microsoft.Office.Interop.Excel.Application xl = 
                    new Microsoft.Office.Interop.Excel.Application();
    
                Workbook wb = 
                    xl.Application.Workbooks.Open(Server.MapPath(filePath));
    
                wb.Activate();
    
                Worksheet ws = wb.Worksheets(1); // use the first sheet 1-based index i think
    
                for (long row = 2; i <= ws.UsedRange.Rows.Count; i++) {
                    // assume row 1 is a title so start at row 2
                    // ws.Cells(row, 1) // company
                    // ws.Cells(row, 2) // phone
                    // ws.Cells(row, 3) // name
                    if (!ws.Cells(row,2).Value2.StartsWith("0") {
                        ws.Cells(row,2).Value2 = "0" + ws.Cells(row,2).Value2
                    }
                }
    
                //string csvPath = (filePath.Replace(".xlsx", ".csv"));
    
                //wb.SaveAs(Server.MapPath(csvPath), 
                //    Microsoft.Office.Interop.Excel.XlFileFormat.xlCSV);
                wb.Save(); // as were directly modifying the file, no need to save elsewhere
    
                wb.Close();             
    
                // call method to parse csv
                //ReadRec(csvPath);
            }
            catch (Exception ex)
            {//}
        else
        {//}
    }
