    dataGridView1.Columns.Add("date", "Date");
			dataGridView1.Columns.Add("day", "Day");
			var day = DateTime.Now;
			DataGridViewRow row = new DataGridViewRow();
			DataGridViewCell cell = new DataGridViewTextBoxCell();
			cell.Value = (Convert.ToDateTime(day.ToString())).DayOfWeek.ToString();
			row.Cells.Add(cell);
			dataGridView1.Rows.Add(row);
			for (int i = 1; i < 10; i++)
			{
				DateTime dtd = Convert.ToDateTime(day).Date;
				dtd = dtd.AddDays(7);
				row = new DataGridViewRow();
				cell = new DataGridViewTextBoxCell();
				cell.Value = dtd.ToString();
				row.Cells.Add(cell);
				DateTime date = dtd;
				cell = new DataGridViewTextBoxCell();
				cell.Value = (Convert.ToDateTime(date.ToString())).DayOfWeek.ToString();
				row.Cells.Add(cell);
				dataGridView1.Rows.Add(row);
			}
