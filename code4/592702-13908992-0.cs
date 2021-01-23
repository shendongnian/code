    private void FillComboBox(string connectionString, string loggedUserID)
            {
                string query = "Select cmodname from modules;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader sqlReader = command.ExecuteReader();
                    try
                    {
                        while (sqlReader.Read())
                        {
                                //ListBox1.Items.Add(sqlReader[0]);
                                treeView2.Nodes[0].Nodes.Add(sqlReader[0]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        sqlReader.Close();
                    }
                }
            }
