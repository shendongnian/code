    var products = (from p in Products
                    join s in SubCategories.Where(x => x.SubCatName == subcategory)
                      on p.SubcatId equals s.SubCatId
                    join b in Brands on p.BrandId equals b.BrandId
                    select new {
                        Subcategory = s.SubCatName,
                        Brand = b.BrandName,
                        p.ProductName,
                        p.ProductPrice
                    }).ToList();
