            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
            try
            {
                con = new OleDbConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("oledbConnection = " + ex.Message);
            }
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("connection open = " + ex.Message + "\n");
            }
