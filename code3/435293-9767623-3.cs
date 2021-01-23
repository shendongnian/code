	sealed class Product
	{
		public string Type
		{
			get;
			set;
		}
	}
	sealed class ProductProcessor
	{
		public void StartProcessing(IEnumerable<Product> products)
		{
			foreach (var group in products.GroupBy(x => x.Type))
				Task.Factory.StartNew(() => ProcessProducts(group));
		}
		private void ProcessProducts(IEnumerable<Product> products)
		{
			foreach (Product product in products)
				ProcessProduct(product);
		}
		private void ProcessProduct(Product product)
		{
		}
	}
