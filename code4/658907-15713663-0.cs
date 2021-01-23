        protected void updateDatabase()
        {
            try
            { 
                // create string variables for form data
                somedata = Request.Form["somedata"].ToString();
                using (SqlConnection sconn = new SqlConnection(myconnstring))
                {
                    using (SqlCommand scmd = new SqlCommand("mystored_procedure", sconn))
                    {
                     scmd.CommandType = CommandType.StoredProcedure;
                     scmd.Parameters.Add("@somedata", SqlDbType.VarChar).Value = strsomedata;
                     scmd.Parameters.Add("@sndtoASPXpage", SqlDbType.Int);
                     scmd.Parameters["@sndtoASPXpage"].Direction = ParameterDirection.Output; 
                     sconn.Open();
                     scmd.ExecuteScalar(); 
                     int returnUID;
                     passmetoASPXpage =     int.Parse(scmd.Parameters["@sendtoASPXpage"].Value.ToString());
    
    //Write to REsponse
          HttpContext.Current.Response.Write(passmetoASPpage.ToString());
            HttpContext.Current.Response.End();
    
    
                    }
                }   
            }
            catch (Exception er)
            {
    
            }
    
    }
