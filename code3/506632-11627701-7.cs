    using System.Linq;
    return _kContext.Products.Select(product => {
        var newProduct = new Product();
        newProduct.Price = product.Price;
        newProduct.DiscountRate = product.DiscountRate;
        if (newProduct.DiscountRate >= 0.3) {
           newProduct.Price += 10;
        }
        return newProduct;
    });
