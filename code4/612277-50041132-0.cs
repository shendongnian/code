        namespace EmailBillingRates
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblProcessing.Text = "";
        }
        private async void btnReadExcel_Click(object sender, EventArgs e)
        {
            string filename = OpenFileDialog();
            
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filename);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            try
            {
                Task<int> longRunningTask = BindGrid(xlRange);
                int result = await longRunningTask;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                //cleanup  
               // GC.Collect();
                //GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:  
                //  never use two dots, all COM objects must be referenced and released individually  
                //  ex: [somthing].[something].[something] is bad  
                //release com objects to fully kill excel process from running in the background  
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);
                //close and release  
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                //quit and release  
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
        }
        private void btnSendEmail_Click(object sender, EventArgs e)
        {
        }
        private string OpenFileDialog()
        {
            string filename = "";
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Excel File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                filename = fdlg.FileName;
            }
            return filename;
        }
        private async Task<int> BindGrid(Microsoft.Office.Interop.Excel.Range xlRange)
        {
            lblProcessing.Text = "Processing File.. Please wait";
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            // dt.Column = colCount;  
            dataGridView1.ColumnCount = colCount;
            dataGridView1.RowCount = rowCount;
        
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //write the value to the Grid  
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                         await Task.Delay(1);
                         dataGridView1.Rows[i - 1].Cells[j - 1].Value =  xlRange.Cells[i, j].Value2.ToString();
                    }
                }
            }
            lblProcessing.Text = "";
            return 0;
        }
    }
    internal class async
    {
    }
}
`
