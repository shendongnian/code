     foreach (DataGridViewRow row in dataGridView1.Rows)
                    switch (Convert.ToDatetime(row.Cells[0].ToString()))
                    {
                       case > DateTime.Today:
                          row.DefaultCellStyle.BackColor = SomeColor;  
                          break;
                       case == DateTime.Today:
                          row.DefaultCellStyle.BackColor = SomeColor;  
                          break;
                        case else:
                          row.DefaultCellStyle.BackColor = SomeColor;  
                          break;
                    }
