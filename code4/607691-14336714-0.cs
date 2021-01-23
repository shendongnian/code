    class PriceData
    {
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
    List<PriceData> prices = ...
    
    var lastPricePerMonth = prices.GroupBy(x => x.Date.Year * 12 + y.Date.Month)
                                  .Select(x => x.OrderByDescending(y => y.Date)
                                                .First());
