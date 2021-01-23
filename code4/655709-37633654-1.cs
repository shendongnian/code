	private getColSum()
	{
		int sum = 0;
		for (int i = 0; i < dataGridView1.Rows.Count; ++i)
		{
			sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
		}
		return sum;
	}
