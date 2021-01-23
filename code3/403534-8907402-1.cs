    using (var con = new SqlConnection(emp_con))
    using (var cmd = con.CreateCommand())
    {
        con.Open();
        cmd.CommandText = 
        @"
            SELECT 
                Crew_Lname, 
                Crew_Fname, 
                Crew_Mname, 
                Crew_Add1, 
                Crew_Add2, 
                Crew_Contact, 
                Crew_Bdate, 
                Rank_Name 
            FROM  
                CREW C, 
                SKILL_RANK SR 
            WHERE 
                C.Rank_Id = SR.Rank_Id 
            AND 
                Crew_Lname LIKE @lName
            AND 
                Crew_Fname LIKE @fName
        ";
        cmd.Parameters.AddWithValue("@lName", txtLname.Text + "%");
        cmd.Parameters.AddWithValue("@fName", txtFname.Text + "%");
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                txtLname.Text = reader.GetString(reader.GetOrdinal("Crew_Lname"));
                txtFname.Text = reader.GetString(reader.GetOrdinal("Crew_Fname"));
                txtMname.Text = reader.GetString(reader.GetOrdinal("Crew_Mname"));
                txtAddress.Text = reader.GetString(reader.GetOrdinal("Crew_Add1"));
                txtAddress1.Text = reader.GetString(reader.GetOrdinal("Crew_Add2"));
                txtContact.Text = reader.GetString(reader.GetOrdinal("Crew_Contact"));
                // Remark: if the Crew_Bdate is a datetime field in your database
                // you should use reader.GetDateTime instead of reader.GetString
                dtpBdate.Text = reader.GetString(reader.GetOrdinal("Crew_Bdate"));
                comRank.Text = reader.GetString(reader.GetOrdinal("Rank_Name"));
            }
        }
    }
