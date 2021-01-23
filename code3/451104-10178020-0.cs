    var Report = (from query in Document.Descendants("order")
                  group query by query.Element("seller").Value into qGroup
                  select new Orders
                  {
                      Seller = qGroup.Key,
                      Quantity = qGroup.Sum(p => int.Parse(p.Element("quantity").Value)).ToString()
                  })
                  .OrderByDescending(order => order.Quantity);
