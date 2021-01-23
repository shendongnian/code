        DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            dt = dsSource.Tables[Index];
            dt.Reset();
            Excel.Workbook workbook;
            Excel.Worksheet NwSheet;
            Excel.Range ShtRange;
            Microsoft.Office.Interop.Excel.Application ExcelObj = new Microsoft.Office.Interop.Excel.Application();
            OpenFileDialog filedlgExcel = new OpenFileDialog();
            filedlgExcel.Title = "Select file";
            filedlgExcel.InitialDirectory = @"c:\";
            //filedlgExcel.FileName = textBox1.Text;
            filedlgExcel.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            filedlgExcel.FilterIndex = 1;
            filedlgExcel.RestoreDirectory = true;
            if (filedlgExcel.ShowDialog() == DialogResult.OK)
            {
                workbook = ExcelObj.Workbooks.Open(filedlgExcel.FileName, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                NwSheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
                ShtRange = NwSheet.UsedRange;
                for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
                {
                    dt.Columns.Add(new DataColumn((ShtRange.Cells[1, Cnum] as Excel.Range).Value2.ToString()));
                }
                dt.AcceptChanges();
                string[] columnNames = new String[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    columnNames[0] = dt.Columns[i].ColumnName;
                }
                //string[] columnNames = (from dc in dt.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();
                for (int Rnum = 2; Rnum <= ShtRange.Rows.Count; Rnum++)
                {
                    DataRow dr = dt.NewRow();
                    for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
                    {
                        if ((ShtRange.Cells[Rnum, Cnum] as Excel.Range).Value2 != null)
                        {
                            dr[Cnum - 1] = (ShtRange.Cells[Rnum, Cnum] as Excel.Range).Value2.ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
                workbook.Close(true, Missing.Value, Missing.Value);
                ExcelObj.Quit();
                dataGridView1.DataSource = dt;  
