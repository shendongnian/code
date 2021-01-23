        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            for (int i = 0; i < 24; i++)
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.HeaderText = string.Format("{0}:00", i+1);
                btnColumn.Name = "dayColumn";
                btnColumn.Width = 40; //set yout width
                dataGridView1.Columns.Add(btnColumn);
            }
            for (int i = 0; i < 7; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    dataGridView1[j, i].Value = string.Format("{0}:00", (j + 1));
            }
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string day = dataGridView1.Rows[e.RowIndex].HeaderCell.Value.ToString();
            string hour = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
            MessageBox.Show("you have clciked on day: " + day + ", hour: " + hour);
        }
