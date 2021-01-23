            var input = System.Xml.Linq.XElement.Parse("*Your XML here*");
            var output = new List<Data>();
            for (int i = 0; i < input.Elements().Count(); i += 5)
            {
                var items = new System.Xml.Linq.XElement(
                     "group", input.Elements().Skip(i).Take(5));
                var item = new Data();
                output.Add(item);
                item.Expr = items.Element("EXPR").Value;
                item.Exch = items.Element("EXCH").Value;
                item.Amount = int.Parse(items.Element("AMOUNT").Value);
                item.NPrices = int.Parse(items.Element("NPRICES").Value);
                var conversion = items.Element("CONVERSION");
                item.Conversion = new Conversion();
                item.Conversion.Date = DateTime.Parse(conversion.Element("DATE").Value);
                item.Conversion.Ask = decimal.Parse(conversion.Element("ASK").Value);
                item.Conversion.Bid = decimal.Parse(conversion.Element("BID").Value);
            }
