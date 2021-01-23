      private void dgParent_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                SqlConnection sc = new SqlConnection(@"Data Source = WARZARU-NB\SQLEXPRESS; Database = proj_1; Integrated Security = True");
            if (dgParent.SelectedCells.Count > 0)
            {
                dgChild.DataSource = null;
                int selectedrowindex = dgParent.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgParent.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells["id"].Value);
                MessageBox.Show(a);
                SqlCommand updateCommand1 = new SqlCommand("Select * FROM tableChild WHERE studentID = @id", sc);
                updateCommand1.Parameters.Add(new SqlParameter("id", a));
                dataAdapter = new SqlDataAdapter(updateCommand1);
                dataSetChild.Clear();
                dataAdapter.Fill(dataSetChild, tableChild);
                dgChild.DataSource = dataSetChild.Tables[tableChild];
            }
            dgParent.AutoResizeColumns();
            dgParent.AutoResizeRows();
        }
