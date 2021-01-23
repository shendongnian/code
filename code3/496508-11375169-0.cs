    public class MemberD
    {
        public SqlCommand cmd = new SqlCommand();
        public SqlConnection con = new SqlConnection("ConStr");
        public SqlDataReader dr;
    public void UpdateMember(string CODE, int COCODE, Member user)
        {
    //Here I added my parameters SQL
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_MSMEMBERS_UPDATE";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
