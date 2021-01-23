    private class Stocks : ExcelReport
        {
            public String StockCode { get; set; }
            public List<Tuple<DateTime, Double, Double>> StocksValues { get; set; }
        }
