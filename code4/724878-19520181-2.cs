     public class Service1 : IService1
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["iwealth_db"]);
            SqlCommand cmd;
            DataSet ds;
            SqlDataAdapter da;
            int result;
            public int user_register(string uname, string pwd)
            {
                cmd = new SqlCommand("sproc_Insertusers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uname",uname);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Direction = ParameterDirection.Output;//Output parameter 
    
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
    
                result = (int)(cmd.Parameters["@id"].Value);
                return result;//returning id 
            }
        }
