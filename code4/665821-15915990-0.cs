    using (SqlConnection con = new SqlConnection("connection string here")) {
        using (SqlCommand cmd = new SqlCommand("sp_Stored_Proc_Name_Here", con)) {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("@VariableNameHere", SqlDbType.VarChar).Value = textBoxNameHere.Text;
          con.Open();
          cmd.ExecuteNonQuery();
        }
    }
