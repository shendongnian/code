    class Data : System.Web.Services.WebService
    {
        public class Record
        {
            public string AccountType { get; set; }
            public string PartDescription { get; set; }
            public int PartNumber { get; set; }
            public string OrderRef { get; set; }
            public DateTime TransactionDate { get; set; }
        }
        [WebMethod]
        public static List<Record> GetData(string param)    
        {
            SqlConnection con = new SqlConnection(@"ConnectionString");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT type,desc,num,ref,date FROM foo", con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Record> records = new List<Record>();
            while (dr.Read())
            {
                records.Add(new Record() {
                    AccountType = dr.GetString(0),
                    PartDescription = dr.GetString(1),
                    PartNumber = dr.GetInt32(2),
                    OrderRef = dr.GetString(3),
                    TransactionDate = dr.GetDateTime(4)                
                });
            }
            dr.Close();
            con.Close();
            return records;
        }
    }
