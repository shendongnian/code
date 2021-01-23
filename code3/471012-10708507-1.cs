    IEnumerable<SpotPriceModel> results =(from result in xml.Descendants(ns + "GetQuoteResult")
                  select new SpotPriceModel    
                {
                    Type = result.Element(ns + "Type").Value,
                    Currency = result.Element(ns + "Currency").Value,
                    Date = result.Element(ns + "Date").Value,
                    Time = result.Element(ns + "Time").Value,
                    Rate = (decimal)result.Element(ns + "Rate"),
                    Bid = (decimal)result.Element(ns + "Bid"),
                    BidTime = result.Element(ns + "BidTime").Value,
                    ExpTime = result.Element(ns + "ExpTime").Value,
                    DisplayTime = result.Element(ns + "DisplayTime").Value,
                    DisplayDate = result.Element(ns + "DisplayDate").Value,
                    Ask = (decimal)result.Element(ns + "Ask"),
                    AskTime = result.Element(ns + "AskTime").Value
                }).AsEnumerable();    
            //var spot = results.First();    
            return View(results);
        }
