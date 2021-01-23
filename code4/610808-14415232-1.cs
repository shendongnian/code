      private void Form1_Load(object sender, EventArgs e)
            {
                dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            } 
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 0)
                {
                    dataGridView1[0, e.RowIndex].Value = !(bool)dataGridView1[0, e.RowIndex].Value;
                
                //Or
                //bool IsBool = false;
                //IsBool = bool.TryParse(dataGridView1[0, e.RowIndex].EditedFormattedValue.ToString(), out IsBool);
                //if (IsBool)
                //   dataGridView1[0, e.RowIndex].Value = IsBool;
                }
            }
