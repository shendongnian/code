    using (OledbConnection cn = new OledbConnection())
                {
                    cn.ConnectionString = OledbConnectionString;
                    cn.Open();
    
                    OledbCommand commandRowCount = new OledbCommand("SELECT COUNT(*) FROM [TABLENAME]", cn);
                    countStart = System.Convert.ToInt32(commandRowCount.ExecuteScalar());
                    MessageBox.Show("Starting row count: " + countStart.ToString());
                }
