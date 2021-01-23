    class Program
    {
        static void Main(string[] args)
        {
            List<string> components = new List<string>();
            //add your 15 components here
            List<Result> results = new List<Result>();
            foreach (string s in components)
            {
                SqlConnection cn = new SqlConnection("conn str here");
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT [Numbers], [Col1], [Col2], [Col3], [Col4] ");
                sb.Append("FROM table ");
                sb.Append("WHERE ( (Col1 = @Component) OR ");
                sb.Append("(Col2 = @Component) OR ");
                sb.Append("(Col3 = @Component) ) ");
                SqlCommand cm = new SqlCommand(sb.ToString(), cn);
                try
                {
                    cn.Open();
                    cm.CommandType = System.Data.CommandType.Text;
                    cm.Parameters.AddWithValue("@Component", s);
                    SqlDataReader dr = cm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            results.Add(new Result(Convert.ToInt32(dr[0].ToString()), 
                                dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                                Convert.ToInt32(dr[4].ToString())));
                        }
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    //handle
                }
                finally
                {
                    cn.Close();
                }
            }
            //process/present results at this point
            
        }
    }
    public class Result
    {
        public int PK { get; set; }
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public int Cost { get; set; }
        public Result( int pk, string col1, string col2, string col3, int cost)
        {
            PK = pk; Col1 = col1; Col2 = col2; Col3 = col3; Cost = cost;
        }
    }
