        using Microsoft.Office.Interop.Excel;
        /// <summary>
        /// sets a cell range's font color
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="startCell"></param>
        /// <param name="endCell"></param>
        /// <param name="color"></param>
        public void setCellRangeFontColor(string filename, string startCell, string endCell, string color)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("EXCEL could not be started. Check that your office installation and project references are correct.");
                return;
            }
            //xlApp.Visible = true;
            //Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Workbook wb = xlApp.Workbooks.Open(filename,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
            Worksheet ws = (Worksheet)wb.Worksheets[1];
            if (ws == null)
            {
                MessageBox.Show("Worksheet could not be created. Check that your office installation and project references are correct.");
            }
            ws.get_Range(startCell, endCell).Font.Color = System.Drawing.ColorTranslator.ToOle(Color.FromName(color));
            wb.Close(true, Type.Missing, Type.Missing);
            //wb.Save();
            xlApp.Quit();
            releaseObject(ws);
            releaseObject(wb);
            releaseObject(xlApp);
        }
        public static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
