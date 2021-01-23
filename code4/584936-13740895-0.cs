     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Web;
     using System.Web.Helpers;
     using EShop.Models.DomainModel;
     using System.Data;
     using EShop.Models.DataAccess;
     using System.Data.Objects;
     using System.Data.Entity.Infrastructure;
    namespace EShop.Models.Repositories
    {
    public class BasketRepository : BaseRepository, IRepository<Basket, Int32>
    {
        public BasketRepository() : base(new EShopData()) { }
        #region CoreMethods
        public void InsertOrUpdate(Basket basket)
        {
            var basketInDB = dbContext.Baskets.SingleOrDefault(b => b.BasketId == basket.BasketId);
            if (basketInDB == null)
                dbContext.Baskets.Add(basket);
        }
        public void Delete(int basketId)
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
        public void Save()
        {
            dbContext.SaveChanges();
        }
        #endregion CoreMethods
        #region AdditionalMethods
        public void AddToBasket(Basket basket, Product product, int quantity)
        {
            var existingProductInBasket = dbContext.BasketProducts.Find(basket.BasketId, product.ProductId);
            if (existingProductInBasket == null)
            {
                var basketProduct = new BasketProduct()
                {
                    BasketId = basket.BasketId,
                    ProductId = product.ProductId,
                    Quantity = quantity
                };
                basket.BasketProducts.Add(basketProduct);   
            }
            else
            {
                existingProductInBasket.Quantity = quantity;
            }
        }
        public void RemoveFromBasket(Basket basket, Product product)
        {
            var existingProductInBasket = dbContext.BasketProducts.Find(basket.BasketId, product.ProductId);
            if (existingProductInBasket != null)
            {
                basket.BasketProducts.Remove(existingProductInBasket); //delete relationship
                dbContext.BasketProducts.Remove(existingProductInBasket); //delete from DB
            }
        }
        public void RemoveFromBasket(BasketProduct basketProduct)
        {
            var basket = dbContext.Baskets.Find(basketProduct.BasketId);
            var existingProductInBasket = dbContext.BasketProducts.Find(basketProduct.BasketId, basketProduct.ProductId);
            if (basket != null && existingProductInBasket != null)
            {
                basket.BasketProducts.Remove(existingProductInBasket); //delete relationship
                dbContext.BasketProducts.Remove(existingProductInBasket); //delete from DB
            }
        }
        public void ClearBasket(Basket basket)
        {
            foreach (var product in basket.BasketProducts.ToList())
                basket.BasketProducts.Remove(product);
        }
        #endregion AdditionalMethods
    }
}
