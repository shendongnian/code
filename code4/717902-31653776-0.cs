            string path = @"C\Desktop\MyExcel.xlsx" //Path for excel
            using Excel = Microsoft.Office.Interop.Excel;
            xlAPP = new Excel.Application();
            xlAPP.Visible = false;
            xlWbk = xlAPP.Workbooks.Open(path);
            string worksheetName = xlWbk.Worksheets.get_Item(1).Name //pass Index here. Reemember that index starts from 1.
            xlAPP.Quit();
            releaseObject(xlWbk);
            releaseObject(xlAPP);
        //Always handle unmanaged code.
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
