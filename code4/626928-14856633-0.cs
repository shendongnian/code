        public class Product
    {
        public int? PictureId { get; set; }
    
        public int Id {get; set;}
    
        public Picture Picture { get; set; }
    
        public bool Enabled { get; set; }
    
        public string Text { get; set; }
    }
    modelBuilder.Entity<Product>().HasOptional<Picture>(pr => pr.Picture).WithMany().HasForeignKey(pr => pr .PictureId);
    public Product GetProductById(int productId)
        {
            var query = from pr in _productRepository.Table
                        where pr.Id == productId
                        select pr;
    
            var product = query.FirstOrDefault();
            AddProductPicture(product);
    
            return product;
        }
    private void AddProductPicture(Product product)
    {
        var query = from pic in _pictureRepository.Table
                            where pic.Id == product.PictureId
                            select pic;
        
                product.Picture = query.FirstOrDefault();
    }
