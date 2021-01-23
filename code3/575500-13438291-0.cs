    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
    
                var c = dataGridView1.Columns.Count;
                 foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        if (comboBox1.SelectedValue==1){
                                    row.Cells[0].Style.BackColor = Color.Green;
                                    row.Cells[0].ToolTipText = "test";
                            }
    
                else
                {
                            row.Cells[0].Style.BackColor = Color.Blue;
                            row.Cells[0].ToolTipText = "test";
                    }
                }
        }
    
    Thanks
