            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                var i = 0;
                foreach (DataGridViewRow row in dgv1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        i++;
                    }
                }
                
                //Enable Button1 if Checkbox is Checked
                if (i > 0)
                {
                    Button1.Enabled = true;
                }
                else
                {
                    Button1.Enabled = false;
                }
            }
        }
