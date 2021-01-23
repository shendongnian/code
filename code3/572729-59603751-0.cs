    	private void ButtonRemoveRows_Click(object sender, EventArgs e)
		{
			DataGridViewRow row;
			int length;
			length = _dataGridView.SelectedRows.Count;
			for(int i = length - 1; i >= 0; i--)
			{
				row = _dataGridView.SelectedRows[i];
				_dataGridView.Rows.Remove(row);
			}
		}
