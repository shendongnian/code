        private void onUserUpdated(DataRow row)
        {
            int idColumn = int.Parse(row["IdColumn"].ToString());
            foreach (DataGridViewRow DGVrow in dataGridView1.Rows)
            {
                if (idColumn == int.Parse(DGVrow.Cells["IdColumn"].Value.ToString()))
                {
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        dataGridView1[i, DGVrow.Index].Value = row.ItemArray[i].ToString();
                    }
                }
            }
        }
