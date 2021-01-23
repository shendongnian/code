    private List<DateTime> GetDates(DataTable dateTypeList, DateTime fromDate, DateTime toDate)
            {
                List<DateTime> results = new List<DateTime>();
                fromDate = Convert.ToDateTime(fromDate.ToShortDateString());
                toDate=Convert.ToDateTime(toDate.ToShortDateString());
    
                int minDay = fromDate.Day;
                int minMonth = fromDate.Month;
                int minYear = fromDate.Year;
                int maxDay = toDate.Day;
                int maxMonth = toDate.Month;
                int maxYear = toDate.Year;
                for (int j = minYear; j <= maxYear; j++)
                {
                    for (int i = 0; i < dateTypeList.Rows.Count; i++)
                    {
    
                        int _day = Convert.ToInt32(dateTypeList.Rows[i]["Day"]);
                        int _month = Convert.ToInt32(dateTypeList.Rows[i]["Month"]);
                        DateTime tempDate = new DateTime(j, _month, _day);
                        if ((tempDate >= fromDate) && (tempDate <= toDate))
                        {
                            results.Add(tempDate);
                        }
    
                    }
                }
    
                return dateTypeList;
                throw new NotImplementedException();
            }
