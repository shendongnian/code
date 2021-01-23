    // assume this is EF generated POCO
    namespace Owner.Project.Data{
        public partial class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
        }
    }
    // this is manually created class in BLL
    using Owner.Project.Data;
    namespace Owner.Product.Business{
        public class StoreProduct : Product {
            public bool Add (string productName){
                // TODO - add product using EF as you normally do
            }
        }
    }
