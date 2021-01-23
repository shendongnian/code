    new code:
            delegate void SetDataGridCallback();
    
            private void updateDataGrid()
            {
                if (this._dbView.InvokeRequired)
                {
                    SetDataGridCallback d = new SetDataGridCallback(updateDataGrid);
                    this.Invoke(d, new object[] {  });
                }
                else
                {
                    using (sCon2 = new SqlConnection("Data Source=" + SettingsForm.getAddress + ";Initial Catalog=" + SettingsForm.getDatabase + ";Integrated Security=False;User Id=" + SettingsForm.getUser + ";Password=" + SettingsForm.getPassword + ";Connect Timeout=0;"))
                    {
                        sCon2.Open();
                        string sqlCommand = "select top 200 * FROM cstPackages order by _dateTime desc"; //reading the db from end to start   
                        using (da = new SqlDataAdapter(sqlCommand, sCon2))
                        {
                            dbDataSet.Clear();
                            da.Fill(dbDataSet, "cstPackages");
                            BindingSource dbBind = new BindingSource(dbDataSet, "cstPackages");
                            _dbView.DataSource = dbBind;
                            _dbView.Refresh();
                             sCon2.Close();
                        }
                    }
                }
            }
