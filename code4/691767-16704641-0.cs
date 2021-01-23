    int idImagen = Convert.ToInt32(listImagenes.Text.Split(':')[0]);
                ImageConverter ic = new ImageConverter();     
    OleDbConnection cnx = new OleDbConnection();
                cnx.ConnectionString = "Your Conection String";
                OleDbCommand cmdx = new OleDbCommand();
                cmdx.Connection = cnx;
                cmdx.CommandText = "SELECT IC.Foto FROM ImageCriminal IC WHERE IC.IdImage=" + idImag;
                cnx.Open();
                byte[] imgRaw = (byte[])cmdx.ExecuteScalar(); //<- Here the byte[] stored in the database gets recovered and stored in imgRaw variable.
                cnx.Close();
                Image imagen = (Image)ic.ConvertFrom((byte[])imgRaw); // This has been working for me from weeks ago!! It's very important to save the files as byte[] inside the DB.
                picBox.Image = imagen;
