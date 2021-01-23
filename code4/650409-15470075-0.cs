    int result=0;
    using (OleDbConnection myConnection = new OleDbConnection ("YourConnectionString"))
    {
        cmd = new OleDbCommand("insert into FWINFOS (ID,Name,Gender,DateOfBirth,Race,WorkingPlace,PassportNO,DateOfExpire,Position,Photo) values (@ID, @Gender, @DateOfBirth, @Race, @WorkingPlace, @PassportNO, @DateOfExpire, @Position, @Photo)", con);
            conv_photo();
            cmd.Parameters.AddWithValue("@ID", textBox5.Text);
            // Specify all parameters like this
            try
            {   
              con.Open();
              result = Convert.ToInt32(cmd.ExecuteNonQuery()); 
            }
            
            catch( OledbException ex)
            {
                 // Log error
            }
            finally
            {
               if (con!=null) con.Close();
                }
            }
    
    if(result > 0)
         // Show success message
