        private void Form1_Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = entities;
			dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
		}
		void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			// you can obtain the value of entered data like this:
			object value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
			string message;
			switch (e.ColumnIndex)
			{
				case 0:
					// bound to integer field
					message = "the value should be a number";
					break;
				case 1:
					// bound to date time field
					message = "the value should be in date time format yyyy/MM/dd hh:mm:ss";
					break;
				// other columns
				default:
					message = "Invalid data";
					break;
			}
			MessageBox.Show(message);
		}
