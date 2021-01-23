	DataGridView grid = new DataGridView();
	System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection();
	public Database()
	{
		grid.CellEndEdit += new DataGridViewCellEventHandler(grid_CellEndEdit);
		grid.UserDeletedRow += new DataGridViewRowEventHandler(grid_UserDeletedRow);
	}
	void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		string query = string.Format(
			"UPDATE Sptblkala {0}='{1}' WHERE kala_id={2}",
			grid.Columns[e.ColumnIndex].Name, grid[e.ColumnIndex, e.RowIndex].Value,
			grid[0, e.RowIndex].Value);
		try
		{
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query,cn);
			cmd.CommandType = System.Data.CommandType.Text;
			cn.Open();
			cmd.ExecuteScalar();
			cn.Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.StackTrace);
		}
	}
	void grid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
	{
		string query = "DELETE FROM Sptblkala WHERE kala_id=" + e.Row.Cells[0].Value;
		try
		{
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cn);
			cmd.CommandType = System.Data.CommandType.Text;
			cn.Open();
			cmd.ExecuteScalar();
			cn.Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.StackTrace);
		}
	}
}
