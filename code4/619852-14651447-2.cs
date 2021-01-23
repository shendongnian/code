    partial class Offer
    {
        public IQueryable<Product> Products 
        { 
           get { return this.ProductOffers.Select(x => x.Product); } 
        }
    }
    partial class Product
    {
        public IQueryable<Offer> Offers 
        { 
           get { return this.ProductOffers.OrderBy(x => x.Sort).Select(x => x.Offer); } 
        }
    }
