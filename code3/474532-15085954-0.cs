            foreach (DataGridViewRow row in dataGridView7.SelectedRows)
            {
                dd = row.Cells["date"].Value.ToString();
                ms = row.Cells["month"].Value.ToString();
                day = row.Cells["day"].Value.ToString();
                string txt = row.Cells["descrip"].Value.ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from holidays where date like '" + dd + "%' and descrip like '"+ txt +"'", con);
                SqlCommand cmd1 = new SqlCommand("delete from stholidays where holiday like '" + dd + "%' and holidescrip like '" + txt + "'", con);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con.Close();
                foreach (DataGridViewCell oneCell in dataGridView7.SelectedCells)
                {
                    if (oneCell.Selected)
                        dataGridView7.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
