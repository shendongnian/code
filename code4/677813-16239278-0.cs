       public bool PriceSystemExist(int PricePlanId, int SurchagePlanId, int _noPlaneId)
       {
          bool isExits = false;
          if (ViewState["_priceSystems"] != null)
          _priceSystems = ViewState["_priceSystems"] as TList<PriceSystemItems>;
        try
        {
          if(_priceSystems != null)
          {
              foreach (PriceSystemItems item in _priceSystems)
             {
                if (item.PricePlanId == PricePlanId &&  item.ServiceTypeId == SurchagePlanId && item.NoMatchAltPlanId ==  _noPlaneId)
            {
                isExits = true;
            }
         }
      }
     }
     catch (Exception ex)
     {
     }
     return isExits;
    }
