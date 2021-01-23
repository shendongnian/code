    private double  _weight;
    public double Weight
        {
            get 
            {
                return _weight;
            }
            set
            {
                _weight = value;
    
                //Shipping cost is 100% dependent on weight. Recalculate it now.
                _shippingCost = 3.25m * (decimal)_weight;
    
                //Retail price is partially dependent on shipping cost and thus on weight as well.  Make sure retail price stays up to date.
                _retailPrice = 1.7m * _wholesalePrice * _shippingCost;
            }
         }
