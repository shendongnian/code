    dataGridView2.AutoGenerateColumns = false;
    ///... assuming that datagridview2 is already created with proper columns
    dataGridView1.AutoGenerateColumns = false;
    dataGridView1.DataSource = dataGridView2.DataSource;
        
        private void btnAdd_Click(object sender, EventArgs e)
                {
        
                    for (int j = 0; j < this.dataGridView2.Columns.Count; j++)
                    {
                        if (dataGridView2.Columns[j].Name == "Description")
                        {
                            this.dataGridView1.Columns.Add(this.dataGridView2.Columns[j].Clone() as DataGridViewColumn);
                        }
                    }
                }
