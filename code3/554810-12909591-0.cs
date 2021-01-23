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
		}
		private void button1_Click(object sender, EventArgs e)
		{
			dt.Rows.Add("str value", value++);
			dataGridView1.DataSource = dt;
		}
