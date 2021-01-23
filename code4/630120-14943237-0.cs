    public class Transaction
    {
        public string Ticker { get; set; }
        public string Action { get; set; }
        public string Date { get; set; }
        public int NumShares { get; set; }
        public double Price { get; set; }
    }
    if (File.Exists("C:\\test.xml"))
    {
        var transList = new List<Transaction>();
        transList.AddRange(from transaction in XDocument.Load("C:\\test.xml").Descendants("transaction")
                            let ticker = transaction.Element("ticker")
                            let action = transaction.Element("action")
                            let date = transaction.Element("date")
                            let shares = transaction.Element("shares")
                            let price = transaction.Element("price")
                            select new Transaction
                                {
                                    Ticker = ticker != null ? ticker.Value : string.Empty,
                                    Action = action != null ? action.Value : string.Empty,
                                    Date = date != null ? date.Value : string.Empty,
                                    NumShares = shares != null ? int.Parse(shares.Value) : default(int),
                                    Price = price != null ? double.Parse(price.Value) : default(double)
                                });
    }
