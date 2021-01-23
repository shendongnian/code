    string connetionString = null;
                SqlConnection connection ;
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = null;
                connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                connection = new SqlConnection(connetionString);
                sql = "delete product where Product_name ='Product6'";
                try
                {
                    connection.Open();
                    adapter.DeleteCommand = connection.CreateCommand();
                    adapter.DeleteCommand.CommandText = sql;
                    adapter.DeleteCommand.ExecuteNonQuery();
                    MessageBox.Show ("Row(s) deleted !! ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
