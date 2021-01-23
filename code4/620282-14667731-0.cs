    private void doctorsDataGridView_UserDeletingRow(object sender, DataGridViewRowsRemovedEventArgs e)
    {
        // Update the balance column whenever rows are deleted.
        try
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [Doctors] WHERE ([DoctorCode] = @code)", Welcome.con);
            cmd.Parameters.Add("@code", SqlDbType.Int).Value = doctorsDataGridView.Rows[e.RowIndex].Cells["DoctorCode"].Value;
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
    }
