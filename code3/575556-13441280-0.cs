	private void b_calculate_Click(object sender, EventArgs e)
	{
		for (var i = 0; i < dataGridView1.RowCount; i++)
		{
			if (dataGridView2.RowCount <= i)
				break;
			var cellFromDG1 = dataGridView1.Rows[i].Cells[0];
			var cellFromDG2 = dataGridView1.Rows[i].Cells[0];
			if (cellFromDG1.Value == null || cellFromDG2.Value == null)
			{
				// this could be the empty row that allows you to
				// enter a new record
				continue;
			}
			var value = cellFromDG1.Value.ToString();
			var value2 = cellFromDG2.Value.ToString();
			if ((value == "AT1" || value == "AE0" || value == "AT2") &&
					(value2 == "BT1" || value2 == "BE0"))
			{
				gottoFunction1();
			}
			if ((value == "AT1" || value == "AT2") &&
				(value2 == "BT1" || value2 == "BT2"))
			{
				gottoFunction2();
			}
		}
	}
