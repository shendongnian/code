    class ProductListingHelper {
        public ProductsViewModel GetProductsViewModel() {
           var products = Products.Build.OffersList();
            var categories = Categories.Build.Main();
            return new ProductsViewModel() {
                Products = products,
                Categories = categories
            };
        }
    }
