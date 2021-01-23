    [Serializable]
    public class ChartLoc
    {
        public string Category { get; set; }
        public List<int> Data{ get; set; }
    }
    
    public string myFunc()
    {
    	string jsonString = "";
        using (SqlConnection con = new SqlConnection(ConnectionString)
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("select * from table", con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
    				List<ChartLoc> _ChartLoc = new List<ChartLoc>();
    
                    while (reader.Read())
                    {
    					ChartLoc chart = new ChartLoc();
    					chart.Data.Add(int.Parse(reader["col2"].ToString()));
    					chart.Data.Add(int.Parse(reader["col3"].ToString()));
    					chart.Data.Add(int.Parse(reader["col4"].ToString()));
    
                        if (reader["store"] != DBNull.Value) 
    						chart.Category = reader["col1"].ToString();
                        _ChartLoc.Add(chart);
                    }
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    jsonString = jss.Serialize(_ChartLoc);
                }
            }
        }
        return jsonString;         
    }
