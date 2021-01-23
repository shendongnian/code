        private void Form1_Load(object sender, EventArgs e)
        {
            string error = "No issues";
            try
            {
                error = "Correct";
            }
            catch (Exception ex)
            {
                error = "Wrong:" + ex.Message.ToString();
            }
            finally
            {
                // Closes connection
            }
            MessageBox.Show(error);
        }
