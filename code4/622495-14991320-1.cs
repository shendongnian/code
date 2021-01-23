    public ProductDto GetProductAvailability(id)
    {
        var result = db.ProductAvailability(id); 
        return new ProductDto
        {
            ProductId = result.productId,
            Availability = new AvailabilityDto
            {
                 InStock = result.inStock,
                 ...
            },
            ...
        }
    }
