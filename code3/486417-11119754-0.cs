                    List<DataRow> toDelete = new List<DataRow>(); 
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        {
                            DataGridViewRow row = dgv.Rows[i];
                            DataGridViewCheckBoxCell check = row.Cells[0] as DataGridViewCheckBoxCell;
                            if (check.Value != null && (bool)check.Value)
                            {
                                DataRow dataRow = (row.DataBoundItem as DataRowView).Row;
                                toDelete.Add(dataRow);
                            }
                        }
                    }
                    toDelete.ForEach(row => row.Delete()); 
