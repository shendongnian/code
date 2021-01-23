    void SaveImage(byte[] image){
            string conStringDatosUsuarios = @" Data Source = \Program Files\GPS___CAM\Data\DatosUsuarios.s3db ";            
            SQLiteConnection con = new SQLiteConnection(conStringDatosUsuarios); 
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = String.Format("INSERT INTO Users (Foto) VALUES (@0);");
            SQLiteParameter p = new SQLiteParameter("@0", System.Data.DbType.Binary);
            p.Value = image;
            cmd.Parameters.Add(p);            
            con.Open(); 
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc1)
            {
                MessageBox.Show(exc1.Message);
            }
            con.Close();
        }
