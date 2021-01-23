    private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = li;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var la = dataGridView1.SelectedCells;
            if (la.Count == 2)
            {
                var rowFirst = ((DataGridViewCell)la[0]).RowIndex;
                var columnFirst = ((DataGridViewCell)la[0]).ColumnIndex;
                var rowSecond = ((DataGridViewCell)la[1]).RowIndex;
                var columnSecond = ((DataGridViewCell)la[1]).ColumnIndex;
                for (int column = 0; column <= columnFirst; column++)
                {
                    dataGridView1[column, rowFirst].Selected = true;
                }
                for (int column = columnSecond; column < dataGridView1.ColumnCount; column++)
                {
                    dataGridView1[column, rowSecond].Selected = true;
                }
            }
        }
