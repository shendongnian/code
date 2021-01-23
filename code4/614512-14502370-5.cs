Ok I'm a bit curious, that you don't find a proper solution. But anyways, the first and simplest approach could be, don't publish the SqlDataReader. Handle its life cycle in the DAL. Means, assuming that you're using my DTO above
public class HomeDAL
{
 public List&lt;Person> DefaultSearchFriends(long userid)
 {
    SqlConnection SocialConn = new SqlConnection(connstr);
    using (SqlCommand comm = new SqlCommand("proc_FriendsSearch", SocialConn))
    {
        comm.CommandType = CommandType.StoredProcedure;
        comm.Parameters.AddWithValue("@userid", userid);
        SocialConn.Open();
        SqlDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
        
        var persons = new List&lt;Person>();
        
        while (dr.Read())
          persons.Add(new Person { Name = dr["Name"], FirstName = dr["FirstName"] });
 
        dr.Close();
        return persons;
    }
 }
}
