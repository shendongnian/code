            Regex reg = new Regex("^[0-9]+\\.[0-9]{1,2}$"); 
            Regex reg1 = new Regex("^[0-9]+\\.[0-9]{2}$");
            if (reg.IsMatch(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()))
            {
                if (!reg1.IsMatch(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()))
                {
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value += "0";
                }
            }
            else
            {
                MessageBox.Show("Please, provide a valid value");
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value = "";
                return;
            }
