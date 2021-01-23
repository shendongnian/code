    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ExcelWorkbook1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Globals.ThisWorkbook.SheetActivate +=
                    new Excel.WorkbookEvents_SheetActivateEventHandler(
                    ThisWorkbook_SheetActivate);
            }
    
            private void ThisWorkbook_SheetActivate(object Sh)
            {
                //Fill your combobox here
            }
        }
    }
