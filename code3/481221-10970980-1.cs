     SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM XYZ WHERE user_id=@user_id,con));
     oCmd.Parameters.AddWithValue("@user_id", user_id);
     int user_number = 0;                 
     con.open();
       using (SqlDataReader oReader = cmd.ExecuteReader())
                {                   
                    while (oReader.Read())
                    {
                       user_number =Convert.ToInt32(oReader["count"]);                                                           
                    }
                    myConnection.Close();
                }                   
                   
               if(user_number == 0)
                       {
                     Response.WriteLine("ERROR");
                     // else part here
                    }
