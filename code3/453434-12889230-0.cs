    batchMembersDataGridView.Rows[e.RowIndex].Cells[16].Value = DateTime.MinValue;
                        
                        if ((DateTime)(batchMembersDataGridView.Rows[e.RowIndex].Cells[16].Value) == DateTime.MinValue)
                        {
                            dataGridViewTextBoxColumn12.DefaultCellStyle.Format = ("");
                        }
