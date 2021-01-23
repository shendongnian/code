    public class HomeDAL
    {
      public void DefaultSearchFriends(ref HomeBAL hBAL)
      {
        SqlConnection SocialConn = new SqlConnection(connstr);
        using (SqlCommand comm = new SqlCommand("proc_FriendsSearch", SocialConn))
        {
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@userid", hBAL.userid);
            SocialConn.Open();
            hBAL.Search_Reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
        }
      }
    }
