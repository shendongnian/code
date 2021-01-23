    var products = from p in new ShopDataContext().Products                           
				   select new Model.Product
				   {
					   Id = p.ProductId,
					   Name = p.ProductName,
					   Price = new Price(
							p.RRP.HasValue ? p.RRP.Value : 0,
							p.SellingPrice.HasValue ? p.SellingPrice.Value : 0)
				   };
