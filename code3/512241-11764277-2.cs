    using System;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel; 
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Excel.Application xlApp ;
                Excel.Workbook xlWorkBook ;
                Excel.Worksheet xlWorkSheet ;
                Excel.Range range ;
    
                string str;
                int rCnt = 0;
                int cCnt = 0;
    
                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Open("csharp.net-informations.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    
                range = xlWorkSheet.UsedRange;
    
                for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
                {
                    for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                    {
                        str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2 ;
                        MessageBox.Show(str);
                    }
                }
    
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
    
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
    
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
    
        }
    }
