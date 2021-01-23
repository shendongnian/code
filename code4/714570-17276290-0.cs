    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            con.Open();
            SqlCommand com = new SqlCommand("Insert Into tbl_notes (Notes,date_time) Values(@Notes,@DateTime)", con);
            com.Parameters.Add(new SqlParameter("@Notes", txtbox_Notes.Text));
            com.Parameters.Add(new SqlParameter("@DateTime", DateTime.Now));
            com.ExecuteNonQuery();
            txtbox_Notes.Text = "";
        }
