    public class ProductMap : ClassMap<Product>
    {
        public class ProductMap()
        {
            Join("Config", join => 
            {
                join.KeyColumn("ProductId");
                join.Component(p => p.Config, c =>
                {
                    c.Map(...);
                });
            }
        }
    }
