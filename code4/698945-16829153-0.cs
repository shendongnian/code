    public void GetImage(string strSQL)
    {
        using( System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection("constring"))
        {
            lock (con)
            {
                using (System.Data.IDbCommand cmd = con.CreateCommand())
                {
                    lock (cmd)
                    {
                        cmd.CommandText = strSQL;
                        if (con.State != System.Data.ConnectionState.Open)
                            con.Open();
                        using (System.Data.IDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess))
                        {
                            lock (reader)
                            {
                                int i = reader.GetOrdinal("Field1");
                                byte[] baImage;
                                System.Drawing.Image img;
                                using (var ms = new System.IO.MemoryStream())
                                {
                                    byte[] buffer = new byte[8040]; // sql page size
                                    int read;
                                    long offset = 0;
                                    while ((read = (int)reader.GetBytes(i, offset, buffer, 0, buffer.Length)) > 0)
                                    {
                                        ms.Write(buffer, 0, read);
                                        offset += read; // oops! added this later... kinda important
                                    } // Whend
                                    baImage = ms.ToArray(); // Here's your image as byte array
                                    img = System.Drawing.Image.FromStream(ms); // Here's your image as image
                                } // End Using ms
                            } // End Lock reader
                        } // End Using reader
                    } // End Lock cmd
                } // End Using cmd
            } // End Lock con
        } // End using con
    } // End Sub GetImage
