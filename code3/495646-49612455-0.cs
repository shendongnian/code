             string connetionString = null;
            SqlConnection connection ;
            SqlCommand command ;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string firstSql = null;
            string secondSql = null;
            connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            firstSql = "Your First SQL Statement Here";
            secondSql = "Your Second SQL Statement Here";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(firstSql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds, "First Table");
                adapter.SelectCommand.CommandText = secondSql;
                adapter.Fill(ds, "Second Table");
                adapter.Dispose();
                command.Dispose();
                connection.Close();
                //retrieve first table data 
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);
                }
                //retrieve second table data 
                for (i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                {
                    MessageBox.Show(ds.Tables[1].Rows[i].ItemArray[0] + " -- " + ds.Tables[1].Rows[i].ItemArray[1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
