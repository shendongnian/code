            string s2 = "Select * from idtyfile where oysterid=@id";
            
            using (SqlConnection conn = new SqlConnection(myConnectionString))
            using (SqlCommand cmd = new SqlCommand(s2, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteReader();
            }
        
