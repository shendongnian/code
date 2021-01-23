    partial class Offer
    {
        public IEnumerable<Product> Products 
        { 
           get { return this.ProductOffers.Select(x => x.Offer); } 
        }
    }
    partial class Product
    {
        public IEnumerable<Offer> Offers 
        { 
           get { return this.ProductOffers.Select(x => x.Product).OrderBy(x => x.Sort); } 
        }
    }
