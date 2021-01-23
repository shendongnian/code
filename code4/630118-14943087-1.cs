    public class Transaction
    {
        public string Ticker { get; set; }
        public string Action { get; set; }
        public string Date { get; set; }
        public int NumShares { get; set; }
        public double Price { get; set; }
    }
    void ReadPortfolio(string filename)
    {
        if (File.Exists(filename))
        {
            var transList = new List<Transaction>();
            foreach (XElement transaction in XDocument.Load(filename).Descendants("transaction"))
            {
                XElement ticker = transaction.Element("ticker");
                XElement action = transaction.Element("action");
                XElement date = transaction.Element("date");
                XElement shares = transaction.Element("shares");
                XElement price = transaction.Element("price");
                transList.Add(new Transaction
                    {
                        Ticker = ticker != null ? ticker.Value : string.Empty,
                        Action = action != null ? action.Value : string.Empty,
                        Date = date != null ? date.Value : string.Empty,
                        NumShares = shares != null ? int.Parse(shares.Value) : default(int),
                        Price = price != null ? double.Parse(price.Value) : default(double)
                    });
            }
        }
    }
