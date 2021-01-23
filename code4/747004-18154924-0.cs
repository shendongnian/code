    try
            {
               // Create an instance of Microsoft Excel and make it invisible
               excelApp = new Excel.Application();
               excelApp.DisplayAlerts = false;
               excelApp.Visible = false;
               // open a Workbook and get the active Worksheet
               excelWorkbooks = excelApp.Workbooks;
               excelWorkbook = excelWorkbooks.Open(excelFile, Type.Missing, true);
               excelWorkSheet1 = excelWorkbook.ActiveSheet;
            }
            catch
            {
               throw;
            }
            finally
            {
               NAR( excelWorkSheet1 );
               excelWorkbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
               NAR(excelWorkbook);
               NAR(excelWorkbooks);
               excelApp.Quit();
               NAR(excelApp);
            }
         }
         private void NAR(object o)
         {
            try
            {
               System.Runtime.InteropServices.Marshal.FinalReleaseComObject( o );
            }
            catch { }
            finally
            {
               o = null;
            }
         }
