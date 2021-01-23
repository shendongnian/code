    public class Class1
    {
        internal List<Complainer> SearchBySurname(string p)
        {
            SqlCommand com = new SqlCommand("select * from Complainers where surname = @sur ");
            com.Parameters.AddWithValue("sur", p);
            List<Complainer> complainers = new List<Complainer>();
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["yourconstring"].ToString()))
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    Complainer c = new Complainer(dr);
                    complainers.Add(c);
                }
            }
            return complainers;
        }
    }
