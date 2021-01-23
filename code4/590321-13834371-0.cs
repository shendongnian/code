    var query = from cust in Customers
                group cust by new { cust.Country, cust.City } into g
                select new
                {
                    CountryName = g.Key.Country,
                    CityGroup = g.Key.City,
                    Orders = g.SelectMany(c => c.Orders)
                };
