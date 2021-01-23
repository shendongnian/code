    foreach (TabPage tbp in tbctrl.TabPages)
            {
                foreach (Control ctrl in tbp.Controls)
                {
                    if (ctrl is DataGridView)
                    {
                        DataGridView newDgv = (DataGridView)ctrl;
                        string strValue = newDgv.Rows[0].Cells[0].Value.ToString();
                    }
                }
            }
