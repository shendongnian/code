    class YearMonth
    {
        public string Year { get; set; }
        public string Month { get; set; }
    }
    
    List<YearMonth> allMonths = List<YearMonth>();
    while (getAllMonthsReader.Read())
    {
         allMonths.Add(new List<YearMonth> {
                                Year = getAllMonthsReader["year"].ToString(),
                                Month = getAllMonthsReader["month"].ToString()
                                            });
    }
    
    getAllMonthsReader.Close();
