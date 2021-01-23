        private void openAllFromDatabase()
        {
            openConnection();
            string query = "select * from my_Table order by date desc";
            DataSet dset = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
            adapter.Fill(dset, "my_Table");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "my_table";
            adapter.Update(dset, "my_Table");
            closeConnection();
        }
