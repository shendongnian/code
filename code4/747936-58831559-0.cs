     try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
                sfd.FileName = "ProfitLoss.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DataTable dts = new DataTable();
                    for (int i = 0; i < grdProfitAndLoss.Columns.Count; i++)
                    {
                        dts.Columns.Add(grdProfitAndLoss.Columns[i].Name);
                    }
                    for (int j = 0; j < grdProfitAndLoss.Rows.Count; j++)
                    {
                        DataRow toInsert = dts.NewRow();
                        int k = 0;
                        int inc = 0;
                        for (k = 0; k < grdProfitAndLoss.Columns.Count; k++)
                        {
                            if (grdProfitAndLoss.Columns[k].Visible == false) { continue; }
                            toInsert[inc] = grdProfitAndLoss.Rows[j].Cells[k].Value;
                            inc++;
                        }
                        dts.Rows.Add(toInsert);
                    }
                    dts.AcceptChanges();
                    ExcelUtlity obj = new ExcelUtlity();
                    obj.WriteDataTableToExcel(dts, "Profit And Loss", sfd.FileName, "Profit And Loss");
                    MessageBox.Show("Exported Successfully");
                }
            }
            catch (Exception ex)
            {
                
            }
