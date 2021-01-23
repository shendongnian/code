    private void button5_Click(object sender, EventArgs e)
    {
        Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
        Excel.Workbook workbook =app.Workbooks.Open(@"C:\Users\Admin\Desktop\Dropbox\Vandit's Folder\Internship\test.xlsx");
        Excel.Worksheet worksheet = workbook.ActiveSheet;
        rcount = worksheet.UsedRange.Rows.Count;
        int i = 0;
        //Initializing Columns
        dataGridView1.ColumnCount = worksheet.UsedRange.Columns.Count;
        for(int x=0;x<dataGridView1.ColumnCount;x++)
        {
                dataGridView1.Columns[x].Name = "Column "+x.ToString();
        }
        for(;i<rcount;i++)
        {
            //dataGridView1.Rows[i].Cells["Column1"].Value = worksheet.Cells[i + 1, 1].Value;
            //dataGridView1.Rows[i].Cells["Column2"].Value = worksheet.Cells[i + 1, 2].Value;
            dataGridView1.Rows.Add(worksheet.Cells[i + 1, 1].Value, worksheet.Cells[i + 1, 2].Value);
        }
    }
