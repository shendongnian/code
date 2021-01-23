    CustomerPart custPart = _custService.Get(custId);
    
    if (DeliveryRunList.HasValue)
    {
        custPart.DeliveryRun_Id = DeliveryRunList.Value;
    }
    
    _custService.Update(custPart);
