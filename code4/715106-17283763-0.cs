        public class Data
        {
            public string Expr { get; set; }
            public string Exch { get; set; }
            public int Amount { get; set; }
            public int NPrices { get; set; }
            public Conversion Conversion { get; set; }
        }
        public class Conversion
        {
            public DateTime Date { get; set; }
            public decimal Ask { get; set; }
            public decimal Bid { get; set; }
        }
