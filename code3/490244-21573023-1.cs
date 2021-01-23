    Cursor.Current = Cursors.WaitCursor;
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "Total Expiry Inventories Data ";
                sfd.DefaultExt = "xls";
                sfd.Filter = "xlsx files(*.xlsx)|*.xlsx";
                if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                Excel.Application ExcelApp = new Excel.Application();
                Excel.Workbook workbook = ExcelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet worksheet1 = (Excel.Worksheet)workbook.Worksheets[1];
                worksheet1.Name = "Expiry Data";
                for (int i = 1; i < GrdViewData.Columns.Count + 1; i++)
                {
                    worksheet1.Cells[1, i] = GrdViewData.Columns[i - 1].HeaderText;
                    worksheet1.Cells[1, i].Font.Bold = true;
                }
                for (int i = 0; i < GrdViewData.Rows.Count; i++)
                {
                    for (int j = 0; j < GrdViewData.Columns.Count; j++)
                    {
                        worksheet1.Cells[i + 2, j + 1] = GrdViewData.Rows[i].Cells[j].Value.ToString();
                    }
                }
                worksheet1.Rows.Font.Size = 12;
                //  Excel.Range range_Consolidated = worksheet1.Rows.get_Range("a1", "d1");
                // range_Consolidated.Font.Bold = true;
                // range_Consolidated.Font.Italic = true;
                string ExcelFileName = sfd.FileName;
                workbook.SaveAs(ExcelFileName);
                workbook.Close(false, ExcelFileName, Missing.Value);
                ExcelApp.Quit();
                ExcelApp = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                MessageBox.Show("File Saved! you can open it from\n  '" + sfd.FileName + "'", "EXPORT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
