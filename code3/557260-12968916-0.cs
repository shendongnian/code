    using Excel = Microsoft.Office.Interop.Excel;
    namespace ExcelInteropDemo
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Excel.Application excel = new Excel.Application();
                excel.Workbooks.Add();
                excel.Visible = true;
                excel.ActiveWorkbook.ActiveSheet.Range("a1").EntireRow.Select();
                excel.Selection.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, 
                    Excel.XlColorIndex.xlColorIndexAutomatic, 
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(79, 129, 189)));
            }
        }
    }
