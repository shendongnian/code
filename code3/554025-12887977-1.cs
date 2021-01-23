            using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM notes WHERE FID = 1356;", con))
            {
 
                using(SqlDataReader noteDrClient = cmd2.ExecuteReader())
                {
 
                    while (noteDrClient.Read()) 
                    {   
                        Note n = new Note();
                        ... get note from data reader
                        notes.Add(n); // add note to collection
                    }
                }
            } 
            // bind child
            nestedRepeater.DataSource = notes;       
            nestedRepeater.DataBind();       
