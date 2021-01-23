    public class GlobalStatsRepository
    {
        public List<GlobalStat> GetStats()
        {
             string sql = @"SELECT * from GlobalStats"; //no, not a good practice
             
            var stats = new List<GlobalStat>();
            
            try
            {
                string ConString = Constants.connString;
                conn = new SqlConnection(ConString);
    
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
    
                while (dr.Read())
                {
                    GlobalStat stat = new GlobalStat();
                    stat.Key = dr[0].ToString();
                    stat.Value = int.Parse(dr[1].ToString());
    
                    stats.Add(stat);
                }
    
            }
            catch (SQLDataReaderException ex)
            {
                logger.Log(ex);
                throw;
            }
        return stats;
        }
    }
