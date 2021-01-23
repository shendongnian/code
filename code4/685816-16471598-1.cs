    class Data
    {
        public static List<Record> GetData(string param)    
        {
            SqlConnection con = new SqlConnection(@"ConnectionString");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM FOO", con);
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
