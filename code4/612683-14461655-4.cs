Just forgot the ToList(), to enumerate the ... enumerations when you do o.Select(...)
    var lpYear = (
        from a in _ds.Tables[0].AsEnumerable()
        join b in LandingPages on a["OFFERINGKEY"].ToString() equals b.Code into c
        from d in c.DefaultIfEmpty()
        where DateTime.Parse(a["PURCHASEDATE"].ToString()) >= DateTime.Parse("January 1, " + year)
        where DateTime.Parse(a["PURCHASEDATE"].ToString()) >= DateTime.Parse("December 31, " + year)
        where LandingPages.Any(x => x.Code == a["OFFERINGKEY"].ToString())
        orderby d.Title
        select new {
            title = d.Title,
            url = d.URL,
            price = a["PRICE"],
            purchased = a["PURCHASEDATE"].ToString()
        }).GroupBy(o => o.title)
        .Select(g => new { 
            total = g.Sum(p => decimal.Parse(p.price.ToString())), 
            count = g.Count(),
            title = g.Key,
            price = g.Select(p=>p.price).ToList(),
            purchased = g.Select(p=>p.purchased).ToList()
        }
    );
