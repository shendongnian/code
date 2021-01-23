    foreach (DataGridViewRow row in GridView2.Rows)
                {
                    if ( ! row.IsNewRow)
                    {
                        for (int i = 0; i < GridView2.Columns.Count; i++)
                        {
                            String header = GridView2.Columns[i].HeaderText;
                            String cellText = Convert.ToString(row.Cells[i].Value);
                        }
                    }
                }
