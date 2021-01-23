    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    
    Namespace WindowsFormsApplication2
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
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
    
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
                
                var xlWorkBooks = xlexcel.Workbooks;
               
                xlexcel.Visible = true;
    
    
                xlWorkBooks.OpenText("C:\\Sample.csv", misValue, misValue, Excel.XlTextParsingType.xlDelimited,
                                     Excel.XlTextQualifier.xlTextQualifierNone, misValue, misValue,
                                     misValue, misValue, misValue, misValue, misValue, misValue, misValue,
                                     misValue, misValue, misValue, misValue);
    
                // Set Sheet 1 as the sheet you want to work with
                xlWorkSheet = (Excel.Worksheet)xlWorkBooks[1].Worksheets.get_Item(1);
    
                xlWorkSheet.Shapes.AddChart(misValue,misValue,misValue,misValue,misValue).Select();
                
                //~~> Make it a Line Chart
                xlexcel.ActiveChart.ApplyCustomType(Excel.XlChartType.xlLineMarkers);
    
                //~~> Set the data range
                xlexcel.ActiveChart.SetSourceData(xlWorkSheet.Range["$A$1:$B$6"]);
    
                //uncomment this if required
                //xlWorkBooks[1].Close(true, misValue, misValue);
                //xlexcel.Quit();
    
                //releaseObject(xlWorkSheet);
                //releaseObject(xlWorkBook);
                //releaseObject(xlexcel);
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
