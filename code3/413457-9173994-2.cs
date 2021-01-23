    from p in Products                         
    join bp in BaseProducts on p.BaseProductId equals bp.Id                    
    where !string.IsNullOrEmpty(p.SomeId) && p.LastPublished >= lastDate                         
    group new { p, bp } by new { p.SomeId } into pg    
    let firstproductgroup = pg.FirstOrDefault()
    let product = firstproductgroup.p
    let baseproduct = firstproductgroup.bp
    let minprice = pg.Min(m => m.p.Price)
    let maxprice = pg.Max(m => m.p.Price)
    select new ProductPriceMinMax
    {
	SomeId = product.SomeId,
	BaseProductName = baseproduct.Name,
	CountryCode = product.CountryCode,
	MinPrice = minprice, 
	MaxPrice = maxprice
    };
