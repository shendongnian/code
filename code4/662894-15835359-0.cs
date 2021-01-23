    public class Item
        {
            public Item(string name, int qty)
            {
                ItemName = name;
                Qty = qty;
            }
    
            public enum DiscountRate
            {
                ZeroPercent = 0,
                FivePercent = 10,
                TenPercent = 26,
                FifteenPercent = 61
    
            }
    
            public override string ToString()
            {
                return string.Format("Items Name: {0} | Units: {1} | Discount Rate: {2}", this.ItemName, this.Qty, this.Rate.ToString() );
            }
    
            public string CalculateDiscount()
            {
                if (this.Qty >= (int)DiscountRate.FifteenPercent)
                {
                    this.Rate = DiscountRate.FifteenPercent;
                    return this.ToString();
                }
                else if (this.Qty >= (int)DiscountRate.TenPercent && this.Qty < (int)DiscountRate.FifteenPercent)
                {
                    this.Rate = DiscountRate.TenPercent;
                    return this.ToString();
                }
                else if (this.Qty < (int)DiscountRate.TenPercent && this.Qty > 9)
                {
                    this.Rate = DiscountRate.FivePercent;
                    return this.ToString();
                }
                else
                {
                    this.Rate = DiscountRate.ZeroPercent;
                    return this.ToString();
                }
            }
    
            public string ItemName { get; set; }
            public int Qty { get; set; }
            public DiscountRate Rate {get; set;}
        }
