    class Trade
    {
        public DateTime Date { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }
    ....
    DateTime sessionBegin = new DateTime(2012, 11, 9, 11, 0, 0);
    DateTime sessionEnd = new DateTime(2012, 11, 9, 12, 0, 0);
    List<Trade> trades = new List<Trade>();
    for(int i = 0; i < hTrades.GetLength(0); i++)
    {
        trades.Add(new Trade()
        {
            Date = new DateTime(hTrades[i, 0], hTrades[i, 1], hTrades[i, 2], hTrades[i, 3], hTrades[i, 4], 0),
            Value1 = hTrades[i, 5],
            Value2 = hTrades[i, 6]
        });
    }
    var sessionTrades = trades.Where(t => t.Date > sessionBegin && t.Date <= sessionEnd);
