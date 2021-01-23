     public class ProductPriceCalculator
     {
        private readonly Product _product;
        private readonly BuyerStrategy _buyerStrategy;
        private readonly DiscountStrategy _discountStrategy;
        private readonly Price _price;
        public ProductPriceCalculator(Product product,BuyerStrategy buyerStrategy,DiscountStrategy discountStrategy,Price price)
        {
            _product = product;
            _buyerStrategy = buyerStrategy;
            _discountStrategy = discountStrategy;
            _price = price;
        }
        public Price CalculatePrice()
        {
            decimal productPrice = _product.BasePrice + (_product.BasePrice * _product.Addition);
            decimal TVA = CalculateTVA();
            decimal discount = CalculateDiscount(productPrice * TVA);
            decimal transportPrice = _product.Transport.GetTransportPrice();
            return _price.CalculatePrice(productPrice*TVA,discount,transportPrice);
        }
        
        ...
     }
    public class Price
    {
        ...
        public virtual Price CalculatePrice(decimal productPrice, decimal discount, decimal transportPrice)
        {
            Price price = new Price();
            price.ProductPrice = productPrice;
            price.Discount = ProductPrice * discount;
            price.ProductPriceWithDiscount = ProductPrice - Discount;
            price.TransportPrice = transportPrice;
            price.TotalPrice = ProductPriceWithDiscount + TransportPrice;
            return price;
        }
        ...
    }
