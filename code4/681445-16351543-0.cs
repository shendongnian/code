    public List<GoodsInfo> GetGoodsList(bool flag)
    {
        List<GoodsInfo> gInfos = new List<GoodsInfo>();
        using (SqlConnection sConn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Conn"].ToString()))
        {
            sConn.Open();
            using (SqlCommand sCmd = new SqlCommand())
            {
                sCmd.Connection = sConn;
                sCmd.CommandText = "select * from P_MKZGood" + (flag ? " where IsCommend = 1" : string.Empty); 
    
                using (SqlDataReader sqlReader = sCmd.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        GoodsInfo gInfo = new GoodsInfo();
                        gInfo.G_ID = Int32.Parse(sqlReader["G_ID"].ToString());
                        gInfo.G_Name = sqlReader["G_Name"].ToString();
                        gInfo.Type = sqlReader["Type"].ToString();
                        gInfo.GoodsType = sqlReader["GoodsType"].ToString();
                        gInfos.Add(gInfo);
                    }
                }
            }
        }
        return gInfos;
    }
