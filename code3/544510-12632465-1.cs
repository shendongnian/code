    var joined = from p in prod.AsEnumerable()
                 join c in categ.AsEnumerable()
                 on p["categid"] equals c["categid"]
                 select new
                 {
                     ProductName = p["prodname"],
                     Category = c["name"]
                 };
    
    var myjoined = joined.ToList();
