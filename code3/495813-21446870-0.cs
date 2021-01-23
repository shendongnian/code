        Excel.Workbook ExWorkbook;
        Excel.Worksheet ExWorksheet;
        Excel.Range ExRange;
        Excel.Application ExObj = new Excel.Application();
        
        DataTable dt = new DataTable("dataTable");
        DataSet dsSource = new DataSet("dataSet");
        dt.Reset();
        openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK) // Test result.
        {
            ExWorkbook = ExObj.Workbooks.Open(openFileDialog1.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            ExWorksheet = (Excel.Worksheet)ExWorkbook.Sheets.get_Item(1);
            ExRange = ExWorksheet.UsedRange;
            for (int Cnum = 1; Cnum <= ExRange.Columns.Count; Cnum++)
            {
                dt.Columns.Add(new DataColumn((ExRange.Cells[1, Cnum] as Excel.Range).Value2.ToString()));
            }
            dt.AcceptChanges();
            string[] columnNames = new String[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                columnNames[0] = dt.Columns[i].ColumnName;
            }
            
            for (int Rnum = 2; Rnum <= ExRange.Rows.Count; Rnum++)
            {
                DataRow dr = dt.NewRow();
                for (int Cnum = 1; Cnum <= ExRange.Columns.Count; Cnum++)
                {
                    if ((ExRange.Cells[Rnum, Cnum] as Excel.Range).Value2 != null)
                    {
                        dr[Cnum - 1] = (ExRange.Cells[Rnum, Cnum] as Excel.Range).Value2.ToString();
                    }
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            ExWorkbook.Close(true, Missing.Value, Missing.Value);
            ExObj.Quit();
            dataGridView1.DataSource = dt;  
