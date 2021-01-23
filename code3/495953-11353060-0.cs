    using System;
    using System.Windows.Forms;
    using System.IO;
    using Excel = Microsoft.Office.Interop.Excel;
    
    Namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            Public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
    
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
    
                // Open a File
                xlWorkBook = xlexcel.Workbooks.Open("C:\\MyFile.xlsx", 0, true, 5, "", "", true,
                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
    
                // Set Sheet 1 as the sheet you want to work with
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                
                //////////////////////////////////////////////////////////
                // REST OF THE CODE HERE TO INTERACT WITH THE WORKSHEET//
                //////////////////////////////////////////////////////////
    
                //Once done close and quit Excel
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();
    
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);
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
    
    
