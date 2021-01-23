        protected void btnUpdate_Click ( object sender, EventArgs e ) 
        {
            GridView2.DataSource = GetFloatRates();
            GridView2.DataBind ( );
        }
        private List<FloatRateItem> GetFloatRates()
        {
            XDocument xmlDoc = XDocument.Load("http://www.floatrates.com/daily/USD.xml");
            var floatRates = xmlDoc.Descendants("channel");
            var items = from i in floatRates.Elements("item")
                        select new FloatRateItem
                        {
                            Title = i.Element("title").Value,
                            Link = i.Element("link").Value,
                            Description = i.Element("description").Value,
                            PubDate = i.Element("pubDate").Value,
                            BaseCurrency = i.Element("baseCurrency").Value,
                            TargetCurrency = i.Element("targetCurrency").Value,
                            ExchangeRate = i.Element("exchangeRate").Value
                        };
            return items.ToList();
        }
        class FloatRateItem
        {
            public string Title { get; set; }
            public string Link { get; set; }
            public string Description { get; set; }
            public string PubDate { get; set; }
            public string BaseCurrency { get; set; }
            public string TargetCurrency { get; set; }
            public string ExchangeRate { get; set; }
            public override string ToString()
            {
                return string.Format(@"<item>
    <title>{0}</title>
    <link>{1}</link>
    <description>{2}</description>
    <pubDate>{3}</pubDate>
    <baseCurrency>{4}</baseCurrency>
    <targetCurrency>{5}</targetCurrency>
    <exchangeRate>{6}</exchangeRate>
    </item>", Title, Link, Description, PubDate, BaseCurrency, TargetCurrency, ExchangeRate);
            }
        }
