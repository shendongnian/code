    SqlConnection con = new SqlConnection(conn);
                con.Open();
                
    
                foreach (string item in attend)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@Name", item));
                    cmd.Parameters.Add(new SqlParameter("@Course", attender.SelectedValue));
                   SqlDataReader dtr = cmd.ExecuteReader();
     dtr.close();
                }
                con.Close();
