    private void button1_Click_1(object sender, EventArgs e) 
    {
        Microsoft.Office.Interop.Excel._Application app  = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel._Workbook workbook =  app.Workbooks.Add(Type.Missing);
        Microsoft.Office.Interop.Excel._Worksheet worksheet = null;                   
        app.Visible = true;
        worksheet = workbook.Sheets["Sheet1"];
        worksheet = workbook.ActiveSheet;
        worksheet.Name = "Exported from gridview";
        for(int i=1;i<dataGridView1.Columns.Count+1;i++)
        {
             worksheet.Cells[1, i] = dataGridView1.Columns[i-1].HeaderText;
        }
        // It's the part which we are interested in
        // we just need to change dataGridView1.Rows to dataGridView1.SelectedRows
        for (int i=0; i < dataGridView1.SelectedRows.Count - 1 ; i++)
        {
            for(int j=0;j<dataGridView1.Columns.Count;j++)
            {
                worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            }
        }
        workbook.SaveAs("c:\\output.xls",Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive , Type.Missing, Type.Missing, Type.Missing, Type.Missing);
      app.Quit();
    }
