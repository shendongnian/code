            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int num = 0;
                if(!dataGridView1.Rows[i].IsNewRow)
                    if (int.TryParse(dataGridView1.Rows[i].Cells[dataGridView1.Columns.Count - 1].Value.ToString(), out num))
                        sum += num;
            }
            dataGridView1.Rows.Add(new object[] { "Total", sum.ToString()});
