      private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                DialogResult question = MessageBox.Show("Are You Sure?", "Please Confirm", MessageBoxButtons.YesNo);
                if ( question == DialogResult.Yes)
                {
                    MessageBox.Show(item.Cells["ID"].Value.ToString());
                    DeleteFromTable(Convert .ToInt32  (item.Cells["ID"].Value));
                   //dataGridView1.Rows.RemoveAt(item.Index);
                   //dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                   
                    
                  
                }
                else
                {
                    
                    break;
                }
            }
        
        }
        public void DeleteFromTable(int primaryKey)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=.\\;Initial Catalog=TestDB;Integrated Security=SSPI;");
            string sqlQuery = @"DELETE FROM Student WHERE ID = " + primaryKey + "(SELECT * from Student)";
            SqlCommand cmd = new SqlCommand(sqlQuery, myConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = new BindingSource(table, null);
            myConnection.Close();
        }
