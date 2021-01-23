    void LoadImage(string tag){
            string query = "SELECT Foto FROM Users;";
            string conString = @" conection to your database ";
            SQLiteConnection con = new SQLiteConnection(conString); 
            SQLiteCommand cmd = new SQLiteCommand(query, con);            
            con.Open();
            try
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();
                try
                {
                    while (rdr.Read())
                    {
                        pictureBox1.Image = ByteToImage((System.Byte[])rdr[0]);
                    }
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            con.Close();
        }
