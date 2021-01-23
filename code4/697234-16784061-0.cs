    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection; 
    private void button1_Click(object sender, EventArgs e)
    {
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook wb = excel.Workbooks.Open(openFileDialog1.FileName);
