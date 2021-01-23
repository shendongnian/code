    private void FillTreeView(string connectionString)
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
    			         if (treeView2.SelectedNode != null)
    			         {
    		                 treeView2.SelectedNode.Nodes.Add(sqlReader[0]);
      		                 treeView2.ExpandAll();
    			         }
    			         else
    			         {
    			             treeView2.Nodes[0].Nodes.Add(sqlReader[0]);
    			         }
    
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
