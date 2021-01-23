    // Your class definitions
    public class YearlyResourceReport
    {
        public YearlyResourceReport()
        {
            this.MonthlyResourceReports = new List<MonthlyOrderInfo>();
        }
        public List<MonthlyOrderInfo> MonthlyResourceReports { get; set; }
    }
    public class MonthlyOrderInfo
    {
        public string Month { get; set; }
        public int MonthNumber { get; set; }
        public OrdersInfo OrdersInfo { get; set; }
    }
    public class OrdersInfo
    {
        public int Id { get; set; }
        public string description { get; set; }
        public int TotalOrders { get; set; }
        public double TotalRevenue { get; set; }
    }
