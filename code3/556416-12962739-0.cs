    	DataTable dt = new DataTable();
		int value = 0;
		private void Form1_Load(object sender, EventArgs e)
		{
			dataGridView1.AutoGenerateColumns = true;
			dt.Columns.AddRange(new DataColumn[]
				{
					new DataColumn("column1", typeof(string)),
					new DataColumn("column2", typeof(int)),
				});
			dt.Rows.Add("row " + value, value++);
			dataGridView1.DataSource = dt;
		}
		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			DataGridViewCell cell = dataGridView1.SelectedCells[0];
			if (e.KeyCode == Keys.Enter && 
				cell.RowIndex == dataGridView1.Rows.Count - 1 && 
				cell.ColumnIndex == dataGridView1.Columns.Count - 1)
				dt.Rows.Add("row " + value, value++);
		}
