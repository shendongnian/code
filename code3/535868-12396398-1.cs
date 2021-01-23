    var products = from p in new ShopDataContext().Products                           
				   select new Model.Product
				   {
					   Id = p.ProductId,
					   Name = p.ProductName,
					   Price = new Price(
							p.RRP ?? 0,
							p.SellingPrice ?? 0)
				   };
