    if (! string.IsNullOrEmpty(cbComboBox1.Text))
    {
        var result = from DataGridViewRow row in dgvData.Rows
                     where row.Cells["Column1"].Value as string != cbComboBox1.Text
                     select row.Index;
        foreach (var i in result)
        {
            dgvData.Rows[i].Visible = false;
        }
    }
