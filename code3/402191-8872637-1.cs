                System.Text.StringBuilder t = new System.Text.StringBuilder();
                String delimiter = ",";
                foreach(DataGridViewCell c in dataGridView1.SelectedRows[0].Cells)
                {
                    t.Append(c.Value);
                    t.Append(delimiter);
                }
                textBox1.Text = t.ToString();
