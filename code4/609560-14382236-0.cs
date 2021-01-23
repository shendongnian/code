    private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        int lastRowIndex = dataGridView1.Rows.Count-1;
        int carId = int.Parse(dataGridView1.Rows[lastRowIndex][0].ToString());
        groupBox2.Enabled = true;
        cmbCarID.Items.Add(carId);
    }
    
