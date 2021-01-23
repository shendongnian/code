    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = sender as CheckBox;
        DataGridView dg = cb.Parent.Controls.Cast<Control>()
                            .Where(c => c.GetType() == typeof(DataGridView))
                            .FirstOrDefault() as DataGridView;
        if (dg != null)
        {              
            if (cb.Checked)
            {
                foreach (DataGridViewRow row in dg.Rows)
                {
                    row.Cells[0].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dg.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }           
        }            
    }  
