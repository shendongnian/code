        public class chartdata
        {
            public string Date { get; set; }
            public int Sales { get; set; }
        }
        [System.Web.Services.WebMethod]//public static web method in code behind
        public static List<chartdata> GetData() //int StartRowindex, 
        {
            List<chartdata> myResult= new List<chartdata>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["demo"].ConnectionString))
            {
                //string sqlString = "SelectbyYearTotalProductAssign";
                string sqlString = "SelectbyYearTotalProductAssign1";
                using (SqlCommand cmd = new SqlCommand(sqlString, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rdr.Read())
                    {
                        chartdata obj = new chartdata();
                        obj.Sales = Convert.ToInt32(rdr["Sales"]);
                        obj.Date = rdr["Date"].ToString();
                        myResult.Add(obj);
                    }
                    conn.Close();
                }
            }
            return myResult;
        }
