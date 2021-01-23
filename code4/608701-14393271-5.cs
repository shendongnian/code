    private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Helper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ToDeleteEmpDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
    
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                    	bool IsBool = false;
                    	if (bool.TryParse(item.Cells[1].EditedFormattedValue.ToString(), out IsBool)) //<--Where: The ColumnIndex of the DataGridViewCheckBoxCell
                    	{
                    		cmd.Parameters.Add("@sno", SqlDbType.Int).Value = item.Cells[0].EditedFormattedValue.ToString(); //<--Where: The ColumnIndex of the Primary key from your DataGridView
                    		dataGridView1.Rows.RemoveAt(item.Cells[0].RowIndex);
                    	}
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
