    var prices = new string[] { "50", "25", "35" };
    var discountPrices = new List<string>() { "10", "5", "3" };
    var items = (from d in context.List
                 where ....
                 select new { d.Name, d.Country }).ToList();
    var list =  (from index in Enumerable.Range(0, items.Count())
                 select new MyNewList
                        {
                            Name = items[index].Name,                    
                            Country = items[index].Country,
                            Price = prices[index],
                            DiscountPrice = discountPrices[index]
                        }).ToList();
