    foreach (DataGridViewRow row in dataGridView2.Rows)
    {
        var serial = row.Cells["CardSerial"].Value;
    
        if (serial != null && serial.ToString().Equals(textBox2.Text))
        {
            row.DefaultCellStyle.BackColor = Color.Yellow;
        }
    }
