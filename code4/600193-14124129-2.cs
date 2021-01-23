            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (dataGridView1.Rows[row.Index].Cells[17].EditedFormattedValue.ToString().Length == 0) //  if (string.IsNullOrWhiteSpace(dataGridView1.Rows[row.Index].Cells[4].EditedFormattedValue.ToString()))
                    break; 
                if (Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[17].EditedFormattedValue) == 0)
                {
                    dataGridView1.Rows[row.Index].Cells[16].Value = null;
                    dataGridView1.Rows[row.Index].Cells[16] = new DataGridViewTextBoxCell();
                    
                }
                else
                {
                    //dgv_Cuotas.Rows[row.Index].Cells[16] = new DataGridViewCheckBoxCell();
                }
            }
