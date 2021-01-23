		DataGridView my_dgvCSV = new DataGridView();
		DataTable my_dataTable = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
		{
			this.Size = new Size(750, 450);
			my_dgvCSV.Size = new Size(600, 400);
			my_dgvCSV.Location = new Point(5, 5);
			string[] raw_txt = File.ReadAllLines(@"D:\urPath\xyz.csv");
			string[] data_col = null;
			int x = 0;
			foreach (string txt_line in raw_txt)
			{
				data_col = txt_line.Split(';'); 
                // My .csv wanted (';') if it looks weird/wrong use (',')
				if (x == 0)
				{//header
					for (int i = 0; i <= data_col.Count() -1; i++)
					{
						my_dataTable.Columns.Add(data_col[i]);
					}
					
					x++;
				}
				else
				{//data
					my_dataTable.Rows.Add(data_col);
				}
			 }
			 my_dgvCSV.DataSource = my_dataTable;
			 this.Controls.Add(my_dgvCSV);
	      }
