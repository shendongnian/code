        List<DataGridViewCell> l = new List<DataGridViewCell>(); 
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            for (int h = 0; h < dataGridView1.Rows[i].Cells.Count; h++)
            {
                l.Add(dataGridView1.Rows[i].Cells[h]);
            }
        }
        bool result = (l.Distinct().Count() == 1);
