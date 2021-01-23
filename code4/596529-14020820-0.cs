    void SelectAllFrom(string query, DataGridView dgv)
            {
                _dataTable.Clear();
                
                try
                {
                    _conn = new MySqlConnection(connection);
                    _conn.Open();
                    _cmd = new MySqlCommand
                    {
                        Connection = _conn,
                        CommandText = query
                    };
                    _cmd.ExecuteNonQuery();
    
                    _da = new MySqlDataAdapter(_cmd);
                    _da.Fill(_dataTable);
    
                    _cb = new MySqlCommandBuilder(_da);
    
                    dgv.DataSource = _dataTable;
                    dgv.DataMember = _dataTable.TableName;
                    dgv.AutoResizeColumns();
    
                    _conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (_conn != null) _conn.Close();
                }
            }
