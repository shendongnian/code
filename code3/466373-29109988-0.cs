                cmd.Parameters["@Descripcion"].Value = descripcion;
                
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);//Aqui se me cae.Aqui se me cae.Aqui .
                                
                cmd.Parameters["@img"].Value = ms.GetBuffer();    //ms.GetBuffer();
                cmd.ExecuteNonQuery();
                return true;
