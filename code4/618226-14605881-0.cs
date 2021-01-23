    private void btnSave_Click(object sender, EventArgs e) {
    if (dgv.RowCount > 1) {
        for (int x = 0; x < dgv.RowCount - 1; x++) {
            if (!String.ISNullOrEmpty(dgv.Rows[x].Cells[0].Value)) {
                SqlCommand cmdSave = new SqlCommand("UPDATE tblRecord SET FName=@FName,   Address=@Address, ContactNo=@ContactNo WHERE IdNo=@IdNo", con);
                {
                    cmdSave.Parameters.Add("@IdNo", SqlDbType.VarChar).Value =   dgv.Rows[x].Cells[0].Value.ToString();
                    cmdSave.Parameters.Add("@FName", SqlDbType.VarChar).Value = dgv.Rows[x].Cells[1].Value.ToString();
                    cmdSave.Parameters.Add("@Address", SqlDbType.VarChar).Value = dgv.Rows[x].Cells[2].Value.ToString();
                    cmdSave.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = dgv.Rows[x].Cells[3].Value.ToString();
                }
                con.Open();
                cmdSave.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated!");
            }
        }
    } 
