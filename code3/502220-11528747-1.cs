    class Program
    {
        static void Main(string[] args)
        {
            List<string> components = new List<string>();
            components.Add("Ing1");
            components.Add("Ing2");
            components.Add("Ing3");
            components.Add("Ing5");
            components.Add("Ing9");
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("(");
            foreach (string s in components)
            {
                string stemp = "'" + s + "'" + ",";
                sb1.Append(stemp);
            }
            int start = sb1.ToString().Length - 2;
            sb1.Replace(",", ")", start, 2);
            List<Result> results = new List<Result>();
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\dbTestCSV.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT [Numbers], [Col1], [Col2], [Col3], [Col4], [Col5]");
            sb.Append("FROM Table1 ");
            sb.Append("WHERE [Col1] IN ");
            sb.Append(sb1.ToString());
            sb.Append(" AND [Col2] IN ");
            sb.Append(sb1.ToString());
            sb.Append(" AND [Col3] IN ");
            sb.Append(sb1.ToString());
            SqlCommand cmd = new SqlCommand(sb.ToString(), con);
            try
            {
                con.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        results.Add(new Result(Convert.ToInt32(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString()));
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            foreach (Result res1 in results)
            {
                Console.WriteLine(res1.PK.ToString());
            }
            Console.ReadLine();
            //process/present results at this point
        }
    }
        
    public class Result
    {
        public int PK { get; set; }
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public string Col4 { get; set; }
        public string Col5 { get; set; }
        public Result(int pk, string col1, string col2, string col3, string col4, string col5)
        {
            PK = pk; Col1 = col1; Col2 = col2; Col3 = col3; Col4 = col4; Col5 = col5;
        }
    }
