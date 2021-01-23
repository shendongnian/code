    using Excel = Microsoft.Office.Interop.Excel;
    public class Form1 {
        
        private void Form1_Load(object sender, System.EventArgs e) {
            Excel.Application oXL = new Excel.Application();
            Excel.Workbook oWB = oXL.Workbooks.Open("C:\\your_path_here\\your_file.xls");
            oXL.Visible = true;
            foreach (Excel.Worksheet oSheet in oWB.Sheets) {
                ComboBox1.Items.Add(oSheet.Name);
            }
            
            ComboBox1.SelectedIndex = 0;
        }
    }
