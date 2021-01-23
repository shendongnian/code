    public static void DELETE_PDT(String rowid)
    {
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand("sp_DELETE_PDT", con);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@rowid", SqlDbType.Int).Value = rowid;
    con.ConnectionString = ConfigurationManager.ConnectionStrings["WMS"].ConnectionString;
    try
    {
        con.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
    }
    catch (Exception ex)
     {
        throw new Exception("Error while deleting record. Please contact your System Administrator", ex);
      }
     }
