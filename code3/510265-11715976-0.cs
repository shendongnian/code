    var result = from article in db.Entities.Articles 
        let lastPrice = (from sale in article.Sales 
                         orderby sale.Date descending 
                         select sale.Price).FirstOrDefault()
        select new
        {
            article.ID_ART,
            article.Designation,
            article.BuyPrice,
            article.SellPrice,
            LastPrice = lastPrice ==0 ? article.BuyPrice : lastPrice
        }
