    public abstract class BaseProduct
    {
        public decimal BasePrice { get; set; }
        public decimal Addition { get; set; }
        public Transport Transport { get; set; }
        public abstract void CalculatePrice(decimal discount);
    }
    public class Product : BaseProduct
    {
        public BasePrice Price { get; set; }
        public Product(BasePrice price)
        {
            this.Price = price;
        }
        public override void CalculatePrice(decimal discount)
        {
            this.Price.CalculatePrice(this.BasePrice, this.Addition, discount);
        }
    }
    public abstract class BasePrice
    {
        public abstract void CalculatePrice(decimal basePrice, decimal additional, decimal discount);
    }
    public class Price : BasePrice
    {
        public decimal ProductPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal ProductPriceWithDiscount { get; set; }
        public decimal TransportPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public override void CalculatePrice(decimal basePrice, decimal additional, decimal discount)
        {
            this.ProductPrice = basePrice + (basePrice * additional);
            this.Discount = this.ProductPrice * discount;
            this.ProductPriceWithDiscount = this.ProductPrice - this.Discount;
            this.TotalPrice = this.ProductPriceWithDiscount + this.TransportPrice;
        }
    }
