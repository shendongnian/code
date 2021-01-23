    public ActionResult GetShoppingCart()
    {
        var cart = Session["cart"] as List<int>;
    
        var products = cart != null ? cart.Select(id => 
                 {
                     var product = GetProductById(id);
                     return new ProductsViewModel
                        {
                           Name = product.Name,
                           Description = product.Description,
                           price = product.Price
                        }
                 }) : new List<ProductsViewModel>();
    
        return PartialView(products);
    }
