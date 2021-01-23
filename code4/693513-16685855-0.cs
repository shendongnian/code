    public partial class Form1 : Form
    {
        private static Excel.Application xlApp;
        private static Excel.Workbook xlWorkBook;
        private static Excel.Worksheet xlWorkSheet;
        private static Excel.Worksheet xlWorkSheet1;
        private static Excel.DocEvents_ChangeEventHandler EventDel_CellsChange;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            xlApp = new Excel.Application();
            xlApp.Visible = true;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet1 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
            //---------------- data is dumped to the excel here----------------  
            ((Microsoft.Office.Interop.Excel._Worksheet)xlWorkSheet).Activate();
            xlApp.EnableEvents = true;
            EventDel_CellsChange = new Excel.DocEvents_ChangeEventHandler(Worksheet_Change);
            xlWorkSheet.Change += EventDel_CellsChange;   
        }
        public static void Worksheet_Change(Excel.Range Target)
        {
            try
            {
                xlApp.EnableEvents = false;
                Excel.Range range = xlWorkSheet.get_Range("Y2");
                range.Formula = "=A2";
            }
            catch (Exception ex)
            {
            }
            finally
            {
                xlApp.EnableEvents = true;
            }
        }
    }
