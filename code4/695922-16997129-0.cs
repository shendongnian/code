    try
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "SQL Server database backup files|*.bak";
                sd.Title = "Create Database Backup";
                
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["project_name.Properties.Settings.project‌​_nameConnectionString"].ConnectionString))
                    {
                        
                            string sqlStmt = string.Format("backup database [" + System.Windows.Forms.Application.StartupPath + "\\dbname.mdf] to disk='{0}'",sd.FileName);
                            using (SqlCommand bu2 = new SqlCommand(sqlStmt, conn))
                            {
                                conn.Open();
                                bu2.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Backup Created Sucessfully");
                            }
                        
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Backup Not Created");
            }
