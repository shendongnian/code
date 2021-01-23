    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel; 
    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Excel.Application xlexcel;
                Excel.Workbook xlWorkBook;
                Excel.Workbook xlWorkBookNew;
                Excel.Sheets worksheets;
                //~~> Path to save the new file
                String NewPath = "C:\\";
                //~~> name of the newly created file
                String NewFileName = "newlycreated";
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
                //~~> Open a File
                xlWorkBook = xlexcel.Workbooks.Open("C:\\Sample.xlsx", 0, true, 5, "", "", true,
                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                //~~> Specify the sheets you want to copy
                String[] selectedSheets = { "a", "c", "d" };
                //~~> Set your worksheets
                worksheets = xlWorkBook.Worksheets;
                //~~>Copy it. This will create a new Excel file with selected sheets
                ((Excel.Sheets)worksheets.get_Item(selectedSheets)).Copy();
                xlWorkBookNew = xlexcel.ActiveWorkbook;
                //~~> Save the new workbook
                xlWorkBookNew.SaveAs(NewPath + NewFileName + ".xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook, 
                misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive,
                misValue, misValue, misValue, misValue, misValue);
                //~~> Loop through the sheets of the new workbook and replace "Sample.xlsx" with "newlycreated.xlsx"
                foreach (Excel.Worksheet xlsheet in xlWorkBookNew.Sheets) 
                {
                    xlsheet.Cells.Replace("Sample.xlsx", NewFileName + ".xlsx", Excel.XlLookAt.xlWhole,
                    Excel.XlSearchOrder.xlByRows, false, false, false);
	            }
                //~~> Close and Cleanup
                xlWorkBookNew.Close(true, misValue, misValue);
                xlWorkBook.Close(false, misValue, misValue);
                xlexcel.Quit();
                releaseObject(worksheets);
                releaseObject(xlWorkBookNew);
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
                    MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
                }
                finally
                {
                    GC.Collect();
                }
            }
        }
    }
