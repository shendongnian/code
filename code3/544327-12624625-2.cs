    private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        if (e.ListChangedType != ListChangedType.ItemDeleted)
        {
            DataGridViewCellStyle violet = dataGridView1.DefaultCellStyle.Clone();
            violet.BackColor = Color.Violet;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Cells[2].Value != null)
                {
                    r.DefaultCellStyle = violet;
                }
            }
        }
    }
