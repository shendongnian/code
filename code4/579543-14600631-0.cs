    public class Organisation_Names
        {
            public DataSet GetOrg_Names()
            {
                SqlConnection cn = new SqlConnection(@"Data Source=XXXXXXXXX;User ID=XXXXXXXXX;Password=XXXXXXXXXXX;Initial Catalog=XXXXXXXXXXXX");
                SqlCommand cmd = new SqlCommand("sp_GetOrg_Names", cn);
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
