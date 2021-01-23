    using (DataTable dt = new DataTable())
                {
                    dt.Columns.Add("column1", typeof(int));
                    dt.Columns.Add("column2", typeof(string));
                    dt.Columns.Add("column3", typeof(int));
                    foreach (DataGridViewRow dgvR in dgQBM.Rows)
                    {
                        dt.Rows.Add(dgvR.Cells[0].Value, dgvR.Cells[1].Value);
                    }
                }
