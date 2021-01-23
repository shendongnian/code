                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            DataGridViewCheckBoxCell chk1 = (DataGridViewCheckBoxCell)row.Cells[0];
                            if ((bool)chk1.Value) // there no chk.Check on datagridview just chk.Selected
                            {
                                string newString = string.Empty;
                                if (comboBox1.SelectedItem != null)
                                {
                                    newString = comboBox1.SelectedItem.ToString();
                                    row.Cells[dataGridView1.Columns.Count - 1].Value = newString;
                                }
                            }
                        }
                    }
