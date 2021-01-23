        class connect
    {
        SqlConnection connector;
        SqlDataReader rdr = null;
        public void askSQL(string sqlQuestion)
        {
            try
            {
                using (connector = new SqlConnection("Your Connection String here"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sqlQuestion;
                    cmd.Connection = connector;
                        rdr = cmd.ExecuteReader();
                        using (rdr)
                        {
                            while (rdr.Read())
                            {
                            }
                        }
                    
                }
            }
            catch (Exception ex)
            {
                if (connector.State == System.Data.ConnectionState.Open)
                    connector.Close();
                MessageBox.Show("Fel vid anslutningen!" + e);
            }
        }
    }
