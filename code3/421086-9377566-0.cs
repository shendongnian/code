    if (tickers.Count() == 0)
                throw new InvalidOperationException("The list of tickers cannot be empty.");
            string url = BuildUrl(tickers);
            WebClient http = new WebClient();            
            string xml = http.DownloadString(url);
            List<Quote> quotes = new List<Quote>();
                        
            XDocument doc = XDocument.Parse(xml);
            foreach (var el in doc.Descendants("quote"))
            {
                if (el.Name == "quote")
                {
                    quotes.Add(new Quote()
                    {
                        Symbol = el.Element("Symbol").Value,                        
                        TradeDate = el.Element("TradeDate").Value,
                        DaysLow = el.Element("DaysLow").IsEmpty ? null : (decimal?)el.Element("DaysLow"),
                        DaysHigh = el.Element("DaysHigh").IsEmpty ? null :(decimal?)el.Element("DaysHigh"),
                        YearLow = el.Element("YearLow").IsEmpty ? null : (decimal?)el.Element("YearLow"),
                        YearHigh = el.Element("YearHigh").IsEmpty ? null : (decimal?)el.Element("YearHigh"),
                        DividendShare = el.Element("DividendShare").IsEmpty ? null : (decimal?)el.Element("DividendShare"),
                        Open = el.Element("Open").IsEmpty ? null : (decimal?)el.Element("Open"),
                        PreviousClose = el.Element("PreviousClose").IsEmpty ? null : (decimal?)el.Element("PreviousClose"),
                        ShortRatio = el.Element("ShortRatio").IsEmpty ? null : (decimal?)el.Element("ShortRatio"),
                        OneyrTargetPrice = el.Element("OneyrTargetPrice").IsEmpty ? null : (decimal?)el.Element("OneyrTargetPrice"),
                        DividendYield = el.Element("DividendYield").IsEmpty ? null : (decimal?)el.Element("DividendYield"),
                        Ask = el.Element("Ask").IsEmpty ?  null : (decimal?)el.Element("Ask"),
                        Bid = el.Element("Bid").IsEmpty ? null : (decimal?)el.Element("Bid"),
                        AskRealtime = el.Element("AskRealtime").IsEmpty ? null : (decimal?)el.Element("AskRealtime"),
                        BidRealtime = el.Element("BidRealtime").IsEmpty ? null : (decimal?)el.Element("BidRealtime"),
                        BookValue = el.Element("BookValue").IsEmpty ? null : (decimal?)el.Element("BookValue"),                                
                        PercentChangeFromYearLow = el.Element("PercentChangeFromYearLow").Value,
                        LastTradeRealtimeWithTime = el.Element("LastTradeRealtimeWithTime").Value,
                        PercebtChangeFromYearHigh = el.Element("PercebtChangeFromYearHigh").Value,
                        LastTradeWithTime = el.Element("LastTradeWithTime").Value,
                        LastTradePriceOnly = el.Element("LastTradePriceOnly").Value,
                        Name = el.Element("Name").Value,
                        Notes = el.Element("Notes").Value,
                        LastTradeTime = el.Element("LastTradeTime").Value,
                        TickerTrend = el.Element("TickerTrend").Value,
                        StockExchange = el.Element("StockExchange").Value,
                        PercentChange = el.Element("PercentChange").Value,
                        AverageDailyVolume = (Int64?)el.Element("AverageDailyVolume"),
                        Change_PercentChange = el.Element("Change_PercentChange").Value,
                        Change = el.Element("Change").Value,
                        Commission = el.Element("Commission").Value,
                        ChangeRealtime = el.Element("ChangeRealtime").Value,
                        LastTradeDate = el.Element("LastTradeDate").Value
                    });
                }
            }
            return quotes;
