        private void btnExport_Click(object sender, EventArgs e)
        {
            
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add(1);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            // changing the name of active sheet
            ws.Name = "Exported from gridview";
            
            ws.Rows.HorizontalAlignment = HorizontalAlignment.Center;
            // storing header part in Excel
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                ws.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            
            
            // storing Each row and column value to excel sheet
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    ws.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            // sizing the columns
            ws.Cells.EntireColumn.AutoFit();
            // save the application
            wb.SaveAs("c:\\output.xls",Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive , Type.Missing, Type.Missing, Type.Missing, Type.Missing);
           
            // Exit from the application
           app.Quit();
        }
    }
