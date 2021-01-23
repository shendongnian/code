            var input = System.Xml.Linq.XElement.Parse("*Your XML here*");
            var output = new List<Data>();
            Data item = new Data();
            foreach(var e in input.Elements())
            {
                if (e.Name == "EXPR")
                {
                    item = new Data();
                    output.Add(item);
                    item.Expr = e.Value;
                }
                else if (e.Name == "EXCH")
                {
                    item.Exch = e.Value;
                }
                else if (e.Name == "AMOUNT")
                {
                    item.Amount = int.Parse(e.Value);
                }
                else if (e.Name == "NPRICES")
                {
                    item.NPrices = int.Parse(e.Value);
                }
                else if (e.Name == "CONVERSION")
                {
                    item.Conversion = new Conversion();
                    item.Conversion.Date = DateTime.Parse(e.Element("DATE").Value);
                    item.Conversion.Ask = decimal.Parse(e.Element("ASK").Value);
                    item.Conversion.Bid = decimal.Parse(e.Element("BID").Value);
                }
            }
