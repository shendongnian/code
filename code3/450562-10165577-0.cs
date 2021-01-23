    int buyVolume = -1;
    int sellVolume = -1;
    decimal buyPrice = decimal.MinValue;
    decimal sellPrice = decimal.MaxValue;
    
    foreach (var order in orders)
    {
        if (order.bidSide)
        {
            if (order.Price > buyPrice)
            {
                buyPrice = order.Price;
                buyVolume = order.Volume;
            }
            else if (order.Price == buyPrice)
            {
                buyVolume += order.Volume;
            }
        }
        else
        {
            if (order.Price < sellPrice)
            {
                sellPrice = order.Price;
                sellVolume = order.Volume;
            }
            else if (order.Price == sellPrice)
            {
                sellVolume += order.Volume;
            }
        }
    }
    // Check sellVolume == -1 to verify whether we've seen any sale orders
    // Check buyVolume == -1 to verify whether we've seen any buy orders
    // Use buyPrice/buyVolume and sellPrice/sellVolume otherwise
