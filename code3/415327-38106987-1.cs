      public class DapperRepository : DapperConnection
      {
           public IEnumerable<TBMobileDetails> ListAllMobile()
            {
                using (IDbConnection con = DapperCon )
                {
                    con.Open();
                    string query = "select * from Table";
                    return con.Query<TableEntity>(query);
                }
            }
         }
