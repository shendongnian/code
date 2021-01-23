    public void InsertOrUpdate(Product product) {
        if (product.Id == default(int)) {
            context.Products.Add(product);
        } else {
            var productInDb = context.Products.Include(p => p.ProductTags)
                .SingleOrDefault(p => p.Id == product.Id);
            if (productInDb != null) {
                // To take changes of scalar properties like Name into account...
                context.Entry(productInDb).CurrentValues.SetValues(product);
                // Delete relationship
                foreach (var tagInDb in productInDb.ProductTags.ToList())
                    if (!product.ProductTags.Any(t => t.Id == tagInDb.Id))
                        productInDb.ProductTags.Remove(tagInDb);
                // Add relationship
                foreach (var tag in product.ProductTags)
                    if (!productInDb.ProductTags.Any(t => t.Id == tag.Id)) {
                        var tagInDb = context.ProductTags.Find(tag.Id);
                        if (tagInDb != null)
                            productInDb.ProductTags.Add(tagInDb);
                    }
            }
        }
