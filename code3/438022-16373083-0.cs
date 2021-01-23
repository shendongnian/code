            string connetionString = null;
            OleDbConnection cnn ;
            connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=yourdatabasename.mdb;";
            cnn = new OleDbConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show ("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
