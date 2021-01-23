      try
    
      {
    
        con = new SqlConnection(constr);
        cmd = new SqlCommand("select photopath,Photo from employees where employeeid=14", con);
        con.Open();
        dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    if (!dr.IsDBNull(1))
                    {
                        byte[] photo = (byte[])dr[1];
                        MemoryStream ms = new MemoryStream(photo);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                  
                   
                }
            }
            catch (Exception ex)
            {
                dr.Close();
                cmd.Dispose();
                con.Close();
                Response.Write(ex.Message);
            }
