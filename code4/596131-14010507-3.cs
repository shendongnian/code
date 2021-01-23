        public IList<ProductDTO> GetProducts()
        {
            using (var db = new NORTHWNDEntities())
            {
                return db.Products.Select(m=>new ProductDTO{Name = m.ProductName}).ToList();
            }     
        }
