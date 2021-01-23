    private int lastSelectedRowIndex;
    
    private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (Char.IsLetter(e.KeyChar))
        {
            for (int i = 0; i < (dataGridView1.Rows.Count); i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString().StartsWith(e.KeyChar.ToString(), true, CultureInfo.InvariantCulture) && lastSelectedRowIndex != i)
                {
                     lastSelectedRowIndex = i;
                     dataGridView1.Rows[i].Cells[0].Selected = true;
                     return;
                }
            }
        }
    }
