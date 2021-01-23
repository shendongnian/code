    private void chkItems_CheckedChanged(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
            if (chk.Value  == chk.TrueValue)
            {
                chk.Value = chk.FalseValue;
            }
            else
            {
                chk.Value = chk.TrueValue;
            }
        }
    }
