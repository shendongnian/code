    class Price
    {
        public DateTime? Timestamp { get; set; }
        public decimal Price { get; set; }
    }
    public IEnumerable<Price> GetPrices(XDocument document)
    {
        return
            from d in document.Root.Elements("D")
            let date = d.Attribute("d")
            from p in d.Elements("P")
            let time = p.Attribute("t")
            select new Price
            {
                Timestamp = (date == null || time == null)
                    ? (DateTime?) null
                    : DateTime.Parse(date.Value + " " + time.Value),
                Price = Convert.ToDecimal(p.Value)
            };
    }
