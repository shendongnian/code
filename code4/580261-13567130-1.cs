                var dt = new DataTable();
                string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI; User ID=userid;Password=pwd;"
                using (var cn = new SqlCeConnection(connectionString )
                using (var cmd = new SqlCeCommand("Select * From yourTable", cn))
                {
                    cn.Open();
                  
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                        //resize the DataGridView columns to fit the newly loaded content.
                        yourDataGridView.AutoSize = true;                                       yourDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        //bind the data to the grid
                        yourDataGridView.DataSource = dt;
                    }
                }
