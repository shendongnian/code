    foreach (PriceSystemItems item in _priceSystems)
    {
            if (item.PricePlanId == PricePlanId &&  item.ServiceTypeId == SurchagePlanId && item.NoMatchAltPlanId ==  _noPlaneId)
            {
                isExits = true;
            }
     }
