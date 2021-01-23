    int roundingId = 0; //0 = no rounding. 1 = dollar rounding. 2 = half-dollar rounding.
    
        var prices = from ps in ObjectContext.Products
        select new
        {
             FinalPrice = GetPrice((ps.IsCustomPrice ? ps.CustomPrice : ps.Retail), roundingId),
        }
    private double GetPrice(double price, int roundingOption)
    {
        switch (roundingOption)
        {
            case 0:
            //Do stuff
            break;
            case 1:
            //Do stuff
            break;
            case 2:
            //Do stuff
            break;
        }
    }
