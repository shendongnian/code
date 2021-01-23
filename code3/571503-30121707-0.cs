    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[0];
                    dataGridView1.BeginEdit(true);
                    if (chk.Value == null || (int)chk.Value == 0)
                    {
                        chk.Value = 1;
                    }
                    else
                    {
                        chk.Value = 0;
                    }
                    dataGridView1.EndEdit();
