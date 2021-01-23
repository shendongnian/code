    public class Result
    {
        private int _daysInMonth;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
    
        public ResultCollection Generate(DateTime fromdate, DateTime enddate)
        {
            var collection = new ResultCollection();
            for (; fromdate < enddate; fromdate = fromdate.AddMonths(1))
            {
                _daysInMonth = DateTime.DaysInMonth(fromdate.Year, fromdate.Month);
                var res = new Result
                                 {
                                     StartDate = fromdate,
                                     EndDate = fromdate.AddDays(_daysInMonth - 1).AddMinutes(-1),
                                     TransactionDate = fromdate.AddDays(_daysInMonth - 1),
                                     Status = "Close"
                                 };
                collection.Add(res);
            }
            collection.ElementAt(collection.Count-1).Status = "Open";
            return collection;
        }
    }
    
    public class ResultCollection : System.Collections.ObjectModel.Collection<Result>
    {
    }
