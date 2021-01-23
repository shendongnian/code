    using Microsoft.Office.Interop.Excel;
    public class ExcelService
    {
        private _Worksheet worksheet;
        private class ComObject<TType> : IDisposable
        {
            public TType Instance { get; set; }
            public ComObject(TType instance)
            {
                this.Instance = instance;
            }
            public void Dispose()
            {
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(this.Instance);
            }
        }
        public void CreateExcelFile(string fullFilePath)
        {
            using (var comApplication = new ComObject<Application>(new Application()))
            {
                var excelInstance = comApplication.Instance;
                excelInstance.Visible = false;
                excelInstance.DisplayAlerts = false;
                try
                {
                    using (var workbooks = new ComObject<Workbooks>(excelInstance.Workbooks))
                    using (var workbook = new ComObject<_Workbook>(workbooks.Instance.Add()))
                    using (var comSheets = new ComObject<Sheets>(workbook.Instance.Sheets))
                    {
                        using (var comSheet = new ComObject<_Worksheet>(comSheets.Instance["Sheet1"]))
                        {
                            this.worksheet = comSheet.Instance;
                            this.worksheet.Name = "Action";
                            this.worksheet.Visible = XlSheetVisibility.xlSheetHidden;
                        }
                        using (var comSheet = new ComObject<_Worksheet>(comSheets.Instance["Sheet2"]))
                        {
                            this.worksheet = comSheet.Instance;
                            this.worksheet.Name = "Status";
                            this.worksheet.Visible = XlSheetVisibility.xlSheetHidden;
                        }
                        using (var comSheet = new ComObject<_Worksheet>(comSheets.Instance["Sheet3"]))
                        {
                            this.worksheet = comSheet.Instance;
                            this.worksheet.Name = "ItemPrices";
                            this.worksheet.Activate();
                            using (var comRange = new ComObject<Range>(this.worksheet.Range["A4"]))
                            using (var comWindow = new ComObject<Window>(excelInstance.ActiveWindow))
                            {
                                comRange.Instance.Select();
                                comWindow.Instance.FreezePanes = true;
                            }
                        }
                        if (this.fullFilePath != null)
                        {
                            var currentWorkbook = (workbook.Instance as _Workbook);
                            currentWorkbook.SaveAs(this.fullFilePath, XlFileFormat.xlWorkbookNormal);
                            currentWorkbook.Close(false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    // Close Excel instance
                    excelInstance.Quit();
                }
            }
        }
    }
