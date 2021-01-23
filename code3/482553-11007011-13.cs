    public List<GlobalStat> GetStatsById(int id)
    {
        var stats = new List<GlobalStat>();
    
        string sql = @"SELECT * from GlobalStats WHERE Id = @Id";
        using (SqlConnection conn = new SqlConnection(ConString))
        {
             conn.Open();
             using (SQLCommand command = new SqlCommand(sql, conn))
             {         
                 command.Parameters.Add(new SqlParameter("Id", id));
                 SqlDataReader reader = command.ExecuteReader();
                 while (reader.Read())
                 {
                      GlobalStat stat = new GlobalStat();
                      stat.Key = dr[0].ToString();
                      stat.Value = int.Parse(dr[1].ToString());
        
                      stats.Add(stat);
                 }
             }
         }
         return stats;
    }
