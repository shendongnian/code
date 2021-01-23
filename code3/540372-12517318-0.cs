    private void dgvOutstandingReports_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
                {
                    int colIndex = e.ColumnIndex;
                    int rowIndex = e.RowIndex;
        
        
                    if (rowIndex >= 0 && colIndex >= 0)
                    {
                        DataGridViewRow theRow = dgvOutstandingReports.Rows[rowIndex];
                        
        
                        if (theRow.Cells[colIndex].Value.ToString() == "Daily Report")
                        {
                            theRow.DefaultCellStyle.BackColor = Color.LightYellow;
                        }
                        else if (theRow.Cells[colIndex].Value.ToString() == "Monthly Report")
                        {
                            theRow.DefaultCellStyle.BackColor = Color.LightGray;
                        }
                        else if (theRow.Cells[colIndex].Value.ToString() == "SMP Report")
                        {
                            theRow.DefaultCellStyle.BackColor = Color.Snow;
                        }
                        else if (theRow.Cells[colIndex].Value.ToString() == "Weekly Report")
                        {
                            theRow.DefaultCellStyle.BackColor = Color.Pink;
                        }
                        else if (theRow.Cells[colIndex].Value.ToString() == "Hourly Report")
                        {
                            theRow.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        }
                    }
                }
