     void dgvSelectAl_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell cellCheck = (DataGridViewCheckBoxCell)dgvSelectAl[e.ColumnIndex, e.RowIndex];
                if (cellCheck != null)
                {
                    if ((bool)cellCheck.Value == true)
                    {
                        checkBoxCounter++;
                    }
                    else
                    {
                        checkBoxCounter--;
                    }
                }
                if (checkBoxCounter == dgvSelectAl.Rows.Count-1)
                {
                    ckBox.Checked = true;
                }
                else if (checkBoxCounter != dgvSelectAl.Rows.Count-1)
                {
                    ckBox.Checked = false;
                }
            }
        }
