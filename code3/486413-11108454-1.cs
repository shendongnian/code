    try {
                    if (dgv.RowCount > 0) {
                        for (int i = 0; i < dgv.Rows.Count;i++ ) {
                            DataGridViewRow row = dgv.Rows[i];
                            DataGridViewCheckBoxCell check = row.Cells[0] as DataGridViewCheckBoxCell;
                            if (check.Value != null) {
                                if ((bool)check.Value) {
                                    dgv.Rows[i].Selected = true;
                                    dgv.Rows[i].Cells[0].Selected = true;
                                    DataRowView currentDataRowView = (DataRowView)dgv.CurrentRow.DataBoundItem;
                                    DataRow dataRow = currentDataRowView.Row;
    
                                    int n = dgv.CurrentRow.Index;
                                    int intID = Convert.ToInt32(dgv.Rows[n].Cells[0].Value);
                                    myTable.Rows.Remove(dataRow);
                                    dgv.DataSource = myTable;
    
                                    Int32 intVal = Convert.ToInt32(row.Cells[1].Value);
                                    if (intVal == intID) {
                                        check.Value = null;
                                    }
                                }
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } 
