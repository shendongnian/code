    public static void DELETE_PDT(String rowid) {
      using (SqlConnection con = new SqlConnection()) {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["WMS"].ConnectionString;
        using (SqlCommand cmd = new SqlCommand("sp_DELETE_PDT", con)) {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("@rowid", SqlDbType.Int).Value = rowid;
          try {
            con.Open();
            cmd.ExecuteNonQuery();
          } catch (Exception ex) {
            throw new Exception("Error while deleting record. Please contact your System Administrator", ex);
          }
        }
      }
    }
