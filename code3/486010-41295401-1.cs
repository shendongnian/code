    public class Demo
    {
        private XEntities _entities = new XEntities();
    
        public void Test(int id)
        {
            var product = _entities.Product.SingleOrDefault(x => x.Id == id);
            product.Type = "New type"; // modifying
    
            int flag = _entities.SaveChanges(); // 0 <<<====
            // or await entities.SaveChangesAsync(); // 0  <<<====
    
            // you need to create new instance of XEntities to apply changes
        }
    }
