    public partial class ShowData : Form
        {
            //use static workbook object to access Worksheets
            public static ThisWorkbook _WORKBOOK;
    
            public ShowData(System.Data.DataTable dt)
            {
                InitializeComponent();
                // binding value to datagrid
                this.dataGridView1.DataSource = dt;
            }
    
            private void RefreshExcel_Click(object sender, EventArgs e)
            {
                Worksheet ws = ShowData._WORKBOOK.ActiveSheet as Worksheet;
                System.Data.DataTable dTable = dataGridView1.DataSource as System.Data.DataTable;
    
                // Write values back to Excel sheet
                // you can pass any worksheet of your choice in ws
                WriteToExcel(dTable,ws);
            }
    
           private void WriteToExcel(System.Data.DataTable dTable,Worksheet ws)
        {
            int col = dTable.Columns.Count; ; 
            int row = dTable.Rows.Count;
            string strRange = "A1";
            string andRange = "D5";
            System.Array arr = Array.CreateInstance(typeof(object),5,4);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    try
                    {
                        arr.SetValue(dTable.Rows[i][j].ToString(), i, j);
                    }
                    catch { }
                }
               
            }
            ws.get_Range(strRange, andRange).Value2 = arr;
            this.Close();
        }
        public static class ExtensionMethods
        {
            static string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            public static string Chr(this int p_intByte)
            {
    
                if (p_intByte > 0 && p_intByte <= 26)
                {
                    return alphabets[p_intByte - 1].ToString();
                }
                else if (p_intByte > 26 && p_intByte <= 700)
                {
                    int firstChrIndx = Convert.ToInt32(Math.Floor((p_intByte - 1) / 26.0));
                    int scndIndx = p_intByte % 26;
                    if (scndIndx == 0) scndIndx = 26;
                    return alphabets[firstChrIndx - 1].ToString() + alphabets[scndIndx - 1].ToString();
                }
    
                return "NA";
            }
    
        }
