    private void btn_Delete_Click(object sender, EventArgs e)
            {
                int selectedCellCount = dgv.GetCellCount(DataGridViewElementStates.Selected);
    
                if (selectedCellCount > 0)
                {
                    string selection;
    
                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        selection = dgv.SelectedCells[i].Value.ToString();
                        string qs_delete = "DELETE FROM yor_table WHERE id = '" + selection + "';";
                        commands.deleteFrom(qs_delete);
                    }
                }
    
    //don't forget to load your table again in dgv
                string qs_select = "SELECT * FROM your_table";
                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataTable.Clear();
                dgv.DataSource = dataTable;
    
                try
                {
                    conn = new MySqlConnection(cs);
                    cmd = new MySqlCommand(qs_select, conn);
                    conn.Open();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(dataTable);
                    cb = new MySqlCommandBuilder(da);
                    dgv.DataSource = dataTable;
                    dgv.DataMember = dataTable.TableName;
                    dgv.AutoResizeColumns();
                    conn.Close();
                }
                catch (Exception ex)
                {
                     MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn != null) conn.Close();
                }
             }
