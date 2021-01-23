    public partial class Basket
    {
        public Basket()
        {
            this.BasketProducts = new List<BasketProduct>();
        }
        public int BasketId { get; set; }
        public int? CustomerId { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public ICollection<BasketProduct> BasketProducts { get; private set; }
        public void AddToBasket(Product product, int quantity)
        {
            //BUSINESS LOGIC HERE
            var productInBasket = BasketProducts.SingleOrDefault(b => b.BasketId == this.BasketId &&  b.ProductId == product.ProductId);
            if (productInBasket == null)
            {
                BasketProducts.Add(new BasketProduct
                {
                    BasketId = this.BasketId,
                    ProductId = product.ProductId,
                    Quantity = quantity
                });
            }
            else
            {
                productInBasket.Quantity = quantity;
            }
        }
        public void RemoveFromBasket(Product product)
        {
            //BUSINESS LOGIC HERE
            var prodToRemove = BasketProducts.SingleOrDefault(b => b.BasketId == this.BasketId && b.ProductId == product.ProductId);
            BasketProducts.Remove(prodToRemove);
        }
    }
}
    public class BasketRepository : BaseRepository, IRepository<Basket, Int32>
    {
        public BasketRepository() : base(new EShopData()) { }
        #region CoreMethods
        //public void InsertOrUpdate(Basket basket, bool persistNow = true) { }
        public void Save(Basket basket, bool persistNow = true)
        {
            var basketInDB = dbContext.Baskets.SingleOrDefault(b => b.BasketId == basket.BasketId);
            if (basketInDB == null)
                dbContext.Baskets.Add(basket);
            if (persistNow)
                dbContext.SaveChanges();
        }
        public void Delete(int basketId, bool persistNow = true)
        {
            var basket = this.GetById(basketId);
            if (basket != null)
            {
                foreach (var product in basket.BasketProducts.ToList())
                {
                    basket.BasketProducts.Remove(product); //delete relationship
                    dbContext.BasketProducts.Remove(product); //delete from DB
                }
                dbContext.Baskets.Remove(basket);
            }
            if (persistNow)
                dbContext.SaveChanges();
        }
        public Basket GetById(int basketId)
        {
            // eager-load product info
            var basket = dbContext.Baskets.Include("BasketProducts")
                                          .Include("BasketProducts.Product.Brand").SingleOrDefault(b => b.BasketId == basketId);
            return basket;
        }
        public IList<Basket> GetPagedAndSorted(int pageNumber, int pageSize, string sortBy, SortDirection sortDirection)
        {
            throw new NotImplementedException();
        }
        public void SaveForUnitOfWork()
        {
            dbContext.SaveChanges();
        }
