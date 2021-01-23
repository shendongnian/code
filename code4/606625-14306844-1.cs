    using( SqlConnection con = new SqlConnection(connenctionstring))
    {
     using(SqlCommand myCMD = new SqlCommand("sp_Test", con))
     {
      myCMD.CommandType = CommandType.StoredProcedure;
      con.Open();
      myCMD.ExecuteNonQuery();//as its insert command
      con.Close();
     }
    }
