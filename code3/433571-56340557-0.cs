            var res = query.Products.Select(m => new
            {
                productID = product.Id,
                categoryID = m.ProductCategory.Select(s => s.Category.ID).ToList(),
            }).ToList();
