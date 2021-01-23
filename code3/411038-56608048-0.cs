    var transactions = (from t in db.Transactions
                            select new
                           {
                               t.SellingPrice,
                               t.CommissionPercent,
                               ...,
                               ...,
				               t.Etc...
                           }).AsEnumerable().Select(x => new HomeModel // Create a model which have following properties
                            {
                               SellingPrice= x.SellingPrice,  //(where SellingPrice is a HomeModel property)
                               AdCategoryTitle = x.CommissionPercent,
                               ...,
                               ...,
                               ETc... = t.Etc...
                           }).ToList();
