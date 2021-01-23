    // On Save.
    int nIdx = 0;
    foreach (DataGridViewRow dgvRow in this.dataGridView.Rows)
    {
        DataGridViewComboBoxCell CB = dgvRow.Cells[yourCell] as DataGridViewComboBoxCell;
        if (String.Compare(CB.Value.ToString(), colComboValues[nIdx++], false) != 0)
        {
            // Value has changed!
        }
        else
        {
            // Value has not.
        }
    }
