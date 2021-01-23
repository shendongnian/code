    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel; 
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //~~> Change Your String here
                String textString = "I'm trying to add a pretty long text into the Excel sheet by using sheet. I use this code:" + Environment.NewLine +
                                   "worksheet.Cells[1, 1] = textString;" + Environment.NewLine +
                                   "The result is here:";
                Clipboard.SetText(textString);
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
                //~~> Add a new a workbook
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                //~~> Set Sheet 1 as the sheet you want to work with
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                //~~> Set your range
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.Paste(CR, false);
                // xlWorkBook.Close(true, misValue, misValue);
                //  xlexcel.Quit();
                // releaseObject(xlWorkSheet);
                // releaseObject(xlWorkBook);
                // releaseObject(xlexcel);
            }
            //private void releaseObject(object obj)
            //{
            //    try
            //    {
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            //        obj = null;
            //    }
            //    catch (Exception ex)
            //    {
            //        obj = null;
            //        MessageBox.Show("Unable to release the Object " + ex.ToString());
            //    }
            //    finally
            //    {
            //        GC.Collect();
            //    }
            //} 
        }
    }
