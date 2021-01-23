            string searchValue = textBox3.Text;
            int rowIndex = -1;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["peseneli"].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
                     
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
