    var lpYear = from o in (from a in _ds.Tables[0].AsEnumerable()
                            join b in LandingPages on a["OFFERINGKEY"].ToString() equals b.Code into c
                            from d in c.DefaultIfEmpty()
                            where DateTime.Parse(a["PURCHASEDATE"].ToString()) >= DateTime.Parse("January 1, " + year)
                            where DateTime.Parse(a["PURCHASEDATE"].ToString()) >= DateTime.Parse("December 31, " + year)
                            where LandingPages.Any(x => x.Code == a["OFFERINGKEY"].ToString())
                            orderby d.Title
                            select new 
                            {
                                title = d.Title,
                                url = d.URL,
                                price = a["PRICE"],
                                purchased = a["PURCHASEDATE"].ToString()
                            })
                 group o by o.title into g
                 select new 
                 { 
                     total = g.Sum(p => decimal.Parse(p.price.ToString())), 
                     count = g.Count(),
                     title = g.Key,
                     url = (from p in g
                            select p.url).Distinct().Single(),
                     code = (from p in g
                             select p.code).Distinct().Single()
                 };
