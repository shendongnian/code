    class TaxCalculator
    {
        private SalesTax[] _Taxes = new SalesTax[] { new BasicSalesTax(), new ImportedDutySalesTax() };
    
        public void Calculate(ShoppringCart shoppringCart)
        {
            foreach (var cartItem in shoppringCart.CartItems)
            {
                cartItem.Tax = _Taxes.Sum(x => x.Calculate(cartItem.Product));
            }
    
        }
    }
