    public class ProductInfoView 
    {
         public string Name { get; set; }
         public int CatalogId { get; set; }
         public int ManufacturerId { get; set; }
         public string CatalogName { get; set; }
         public string ManufacturerName { get; set; }
    }
    from p in Product
    join c in Catalog on c.Id equals p.CatalogId
    join m in Manufacturer on m.Id equals p.ManufacturerId
    where p.Active == 1
    select new ProductInfoView() { Name = p.Name, CatalogId = p.CatalogId, ManufacturerId = p.ManufacturerId, CatalogName = c.Name, ManufacturerName = m.Name };
