	public class Product
	{
		public int ProductId { get; private set; }
		public int SupplierId { get; private set; }
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public int Stock { get; private set; }
		public int PendingStock { get; private set; }
		public Product(int id)
        {
			using(var db = new MainContext())
            {
				var q = (from c in product where c.ProductID = id select c).SingleOrDefault();
				if(q!=null)
					LoadByRec(q);			
			}
		}
		public Product(product rec)
		{
			LoadByRec(q);
		}
		public void LoadByRec(product rec)
		{
			ProductId = rec.product_id;
			SupplierID = rec.supplier_id;
			Name = rec.name;
			Price = rec.price;
			Stock = rec.total_stock;
			PendingStock = rec.pending_stock;
		}
	}
