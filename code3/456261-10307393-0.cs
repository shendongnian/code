    try
                {
                   string x = TextBox1.Text;
                   string Connection ="Data Source=" + x + ";Initial Catalog=ZBERUDAJOVTEPLA;Persist Security Info=False;User ID=sa; password=diplomovka";
                    using (var conn = new SqlConnection(Connection))
                    {
                        using (var cmd = new SqlCommand("Select * from Yourtable", conn))
                        {
                           
                            try
                            {
                                conn.Open(); 
    
                            }
                            catch (SqlException)
                            {
                                throw;
                            }
                            finally
                            {
                                if (conn.State == ConnectionState.Open) conn.Close();
                            }
    
                        }
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
