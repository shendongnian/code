    abstract class SalesTax
    {
        abstract public bool IsApplicable(Product item);
        abstract public decimal Rate { get; }
    
        public decimal Calculate(Product item)
        {
            if (IsApplicable(item))
            {
                //sales tax are that for a tax rate of n%, a shelf price of p contains (np/100)
                var tax = (item.ShelfPrice * Rate) / 100;
    
                //The rounding rules: rounded up to the nearest 0.05
                tax = Math.Ceiling(tax / 0.05m) * 0.05m;
    
                return tax;
            }
    
            return 0;
        }
    }
    
    class BasicSalesTax : SalesTax
    {
        private ProductType[] _taxExcemptions = new[] 
        { 
            ProductType.Food, ProductType.Medical, ProductType.Book 
        };
    
        public override bool IsApplicable(Product item)
        {
            return !(_taxExcemptions.Any(x => item.IsOf(x)));
        }
    
        public override decimal Rate { get { return 10.00M; } }
    }
    
    class ImportedDutySalesTax : SalesTax
    {
        public override bool IsApplicable(Product item)
        {
            return item.IsImported;
        }
    
        public override decimal Rate { get { return 5.00M; } }
    }
