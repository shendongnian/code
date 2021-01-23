    Product product = new Product();
    product.CreateDateTime = DateTime.Now;
    product.Description = productCreateModel.Product.Description;
    product.ManufacturerId = productCreateModel.Manufacturer;
    product.MetaDescription = productCreateModel.Product.MetaDescription;
    product.MetaTitle = productCreateModel.Product.MetaTitle;
    product.Name = productCreateModel.Product.Name;
    product.Status = ProductStatuses.Active;
    product.URL = productCreateModel.Product.URL;
    db.Products.Add(product);
    if (productCreateModel.ProductImage1.ContentLength > 0)
        {
            BinaryReader binaryReader = new BinaryReader(productCreateModel.ProductImage1.InputStream);
            ProductImage image = new ProductImage()
            {
                  CreateDateTime = DateTime.Now,
                  Image = binaryReader.ReadBytes(productCreateModel.ProductImage1.ContentLength),
                  PrimaryImage = true
            }
            db.ProductImages.Add(image); // Add the image to the ProductImage entity set
            product.ProductImages.Add(image); // link the image to this Product
        }
    
    db.SaveChanges(); // Save all changes
