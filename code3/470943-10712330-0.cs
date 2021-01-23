            string url = "http://www..../...";
            var xml = XElement.Load(url);
            XNamespace ns = "http://.../...";
            var results =
                from result in xml.Descendants(ns + "GetMetalQuoteResult")
                select new SpotPriceModel
                {
                    Type = result.Element(ns + "Type").Value,
                    Currency = result.Element(ns + "Currency").Value,
                    ...
                    ...
                    Ask = (decimal)result.Element(ns + "Ask"),
                    AskTime = result.Element(ns + "AskTime").Value
                };
            var spot = results.First();
            System.Diagnostics.Debug.WriteLine("\n\nASK:\t" + spot.Ask + "\n\n");
            return View(spot);
        }
