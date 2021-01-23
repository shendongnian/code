    private void dgvChq_CellValidating(object sender, 
                                       DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex != 5)
            return;
        HandleCheckedChanged(dgvChq, e, 
                             Convert.ToInt32(dgvChq.Rows[e.RowIndex].Cells[0].Value));
    }
    private void dgvCredit_CellValidating(object sender, 
                                          DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex != 0)
            return;
        HandleCheckedChanged(dgvCredit, e, 
                             Convert.ToInt32(dgvCredit.Rows[e.RowIndex].Cells[1].Value));
    }
    private void HandleCheckedChanged(DataGridView dgv, 
                                      DataGridViewCellValidatingEventArgs e, int id)
    {
        object toBeDisplayedDateValue = (bool)e.FormattedValue ? (DateTime?)DateTime.Today : null;
        using (SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandText = @"UPDATE Customer.OrderHeader 
                                SET    DateApproved = @approvedDate 
                                WHERE  OrderNumber = @ordNo";
            cmd.Parameters.AddWithValue("@approvedDate", toBeDisplayedDateValue);
            cmd.Parameters.AddWithValue("@ordNo", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        dgv.Rows[e.RowIndex].Cells[4].Value = toBeDisplayedDateValue; //you could just do this much
        //or
        //DataGridViewRow dgvr = dgv.SelectedRows[0]; //this line works only if there is                                                    //at least one selected row when 
                                                      //validating cell. For this you 
                                                      //require 
                                                      //dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    }
