        [WebMethod]
        public Currency_Object get_currency(string date, string cur_code) {
            
            Currency_Object co = new Currency_Object();
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=xxx-xxx;Initial Catalog=MB_DB;Persist Security Info=True;User ID=xxx;Password=xxx"))
                {
                    string selectSql = "select date,code,banknote_buying,banknote_selling from Currencies where date = '" + date + "' and code ='" + cur_code + "'";
                    SqlCommand comm = new SqlCommand(selectSql, conn);
                    conn.Open();
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.Read()) {
                        co.date_ = dr["date"].ToString();
                        co.code_ = dr["code"].ToString();
                        co.banknote_buying_ = dr["banknote_buying"].ToString();
                        co.banknote_selling_ = dr["banknote_selling"].ToString();
                    }
                }
            }
            catch (Exception ex) { return null; }
            return co;
        }
    }
