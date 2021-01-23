    if (textBox1.Text != string.Empty)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[column_index].ToString().Trim().Contains(textBox1.Text.Trim()))
                        {
                            row.Visible = true;
                        }
                        else
                            row.Visible = false;
                    }
                }
