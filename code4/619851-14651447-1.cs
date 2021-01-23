    partial class Offer
    {
        public IQueryable<Product> Products 
        { 
           get { return this.ProductOffers.Select(x => x.Offer); } 
        }
    }
    partial class Product
    {
        public IQueryable<Offer> Offers 
        { 
           get { return this.ProductOffers.Select(x => x.Product).OrderBy(x => x.Sort); } 
        }
    }
