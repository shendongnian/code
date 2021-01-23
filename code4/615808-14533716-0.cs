    class DailyPrice
    {
        DateTime Date { get; set; }
        decimal Open { get; set; }
        decimal Close { get; set; }
        decimal High { get; set; }
        decimal Low { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            List<DailyPrice> prices = new List<DailyPrice>();
            prices.Add(new DailyPrice() { Date = DateTime.Today, Open = 11.11M, Close=... });
            prices.Add(new DailyPrice() { Date = DateTime.Today, Open = 12.14M, High=... });
            ...
        }
    }
   
