            string s2 = "Select * from idtyfile where oysterid=@id";
            DataTable myDataTable = new DataTable();
            
            using (SqlConnection conn = new SqlConnection(myConnectionString))
            using (SqlCommand cmd = new SqlCommand(s2, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                myDataTable.Load(cmd.ExecuteReader());
            }
