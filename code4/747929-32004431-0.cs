            private void btnExportExcel_Click(object sender, EventArgs e)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    int StartCol = 1;
                    int StartRow = 1;
                    int j = 0, i = 0;
    
                    //Write Headers
                    for (j = 0; j < dgvSource.Columns.Count; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                        myRange.Value2 = dgvSource.Columns[j].HeaderText;
                    }
    
                    StartRow++;
    
                    //Write datagridview content
                    for (i = 0; i < dgvSource.Rows.Count; i++)
                    {
                        for (j = 0; j < dgvSource.Columns.Count; j++)
                        {
                            try
                            {
                                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                                myRange.Value2 = dgvSource[j, i].Value == null ? "" : dgvSource[j, i].Value;
                            }
                            catch
                            {
                                ;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
