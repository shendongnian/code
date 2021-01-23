      private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                 DataGridViewRow row = DataGridViewRow)dataGridView1.Rows[e.RowIndex];
                 SqlDataAdapter da2;
                 DataTable dt2 = new DataTable();
                 da2 = new SqlDataAdapter("SELECT ID, Name, Surname, City FROM tblStudents2 WHERE Name = '" + row["Name"].Value.ToString()+ "'", con);
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;
            }
        }
