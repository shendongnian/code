     private void button1_Click(object sender, EventArgs e)
        {
            
            Excel03to07("D:\\TestExls\\TestExcelApp.XLS");
        }
        private void Excel03to07(string fileName)
        {
            string svfileName = Path.ChangeExtension(fileName, ".xlsx");
            object oMissing = Type.Missing;
            var app = new Microsoft.Office.Interop.Excel.Application();
            var wb = app.Workbooks.Open(fileName, oMissing, oMissing,
                            oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
            wb.SaveAs(svfileName, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            wb.Close(false, Type.Missing, Type.Missing);
            app.Quit();
            GC.Collect();
            Marshal.FinalReleaseComObject(wb);
            Marshal.FinalReleaseComObject(app);
       }
