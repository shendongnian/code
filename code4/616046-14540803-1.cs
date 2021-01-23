     private void txtbCode_TextChanged(object sender, EventArgs e)
     {
         txtCatogery.Text = String.Empty;
         txtDiscriptions.Text = String.Empty;
         ...
         try
         {
            MySqlCommand com = new MySqlCommand();
            MySqlDataReader read;
            .....
