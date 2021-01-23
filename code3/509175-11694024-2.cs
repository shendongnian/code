    private void Form1_Load(object sender, EventArgs e)
    {
        //---------------------------------------------
        // load dgv...
        //---------------------------------------------
        dgvChq.CellValueChanged += dgvChq_CellValueChanged;
        dgvCredit.CellValueChanged += dgvCredit_CellValueChanged;
    }
    private void dgvChq_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != 5)
            return;
        HandleCheckedChanged(dgvChq, e, 0);
    }
    private void dgvCredit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != 0)
            return;
        HandleCheckedChanged(dgvCredit, e, 1);
    }
    private void HandleCheckedChanged(DataGridView dgv, DataGridViewCellEventArgs e, 
                                      int columnIndexOfOrderNo)
    {
        DataGridViewCheckBoxCell c = dgv[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;
        object toBeDisplayedDateValue = (bool)c.EditedFormattedValue ? (DateTime?)DateTime.Today : null;
        using (SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandText = @"UPDATE Customer.OrderHeader 
                                SET    DateApproved = @approvedDate 
                                WHERE  OrderNumber = @ordNo";
            cmd.Parameters.AddWithValue("@approvedDate", toBeDisplayedDateValue);
            cmd.Parameters.AddWithValue("@ordNo", 
                                        Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[columnIndexOfOrderNo].Value));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        dgv.Rows[e.RowIndex].Cells[4].Value = toBeDisplayedDateValue;
    }
