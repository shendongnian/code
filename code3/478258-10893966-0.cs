    sql = new SqlConnection(Connection.con);
                adapter = new SqlDataAdapter(@"select EntryID * from Table where Name like @Name ", sql);
                adapter.SelectCommand.Parameters.AddWithValue("@Name", string.Format("%{0}%", textBox1.Text));
                dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
