    string LoadImage() {
        string query = "select Photo from Table;"; 
        string conString = @" Data Source = \Program Files\Users.s3db ";            
        SQLiteConnection con = new SQLiteConnection(conString); 
        SQLiteCommand cmd = new SQLiteCommand(query, con);
        string base64EncodedImage = null;
        con.Open(); 
        try {
            IDataReader reader = cmd.ExecuteReader();
            reader.Read(); // advance the data reader to the first row
            base64EncodedImage = (string) reader["Photo"];
            reader.Close();
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message);
        }
        con.Close();
        return base64EncodedImage;
    }
