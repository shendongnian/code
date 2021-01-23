     using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connSpionshopString"].ConnectionString))
     {
                connection.Open();
                string sql =  "INSERT INTO klant(klant_id,naam,voornaam) VALUES(@param1,@param2,@param3)";
                using(SqlCommand cmd = new SqlCommand(sql,connection)) 
                {
                      cmd.Parameters.Add("@param1", SqlDbType.Int).value = klantId;  
                      cmd.Parameters.Add("@param2", SqlDbType.Varchar, 50).value = klantNaam;
                      cmd.Parameters.Add("@param3", SqlDbType.Varchar, 50).value = klantVoornaam;
                      cmd.CommandType = CommandType.Text;
                      cmd.ExecuteNonQuery(); 
                }
     }
