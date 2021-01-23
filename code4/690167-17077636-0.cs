        static ShippingDetailsType BuildShippingDetails()
        {
            // Shipping details
            ShippingDetailsType sd = new ShippingDetailsType();
            sd.ApplyShippingDiscount = true;
            sd.PaymentInstructions = "eBay .Net SDK test instruction.";
            sd.ShippingRateType = ShippingRateTypeCodeType.StandardList;
            // Shipping type and shipping service options
            //adding international shipping
            InternationalShippingServiceOptionsType internationalShipping1 = new InternationalShippingServiceOptionsType();
            internationalShipping1.ShippingService = ShippingServiceCodeType.StandardInternational.ToString();
            internationalShipping1.ShippingServiceCost = new AmountType { Value = 0, currencyID = CurrencyCodeType.USD };
            internationalShipping1.ShippingServicePriority = 1;
            internationalShipping1.ShipToLocation = new StringCollection(new[] { "Worldwide" });
            sd.ShippingServiceUsed = ShippingServiceCodeType.StandardInternational.ToString();
            sd.InternationalShippingServiceOption = new InternationalShippingServiceOptionsTypeCollection(new[] { internationalShipping1 });
            //adding domestic shipping
            ShippingServiceOptionsType domesticShipping1 = new ShippingServiceOptionsType();
            domesticShipping1.ShippingService = ShippingServiceCodeType.ShippingMethodStandard.ToString();
            domesticShipping1.ShippingServiceCost = new AmountType { Value = 0, currencyID = CurrencyCodeType.USD };
            domesticShipping1.ShippingInsuranceCost = new AmountType { Value = 0, currencyID = CurrencyCodeType.USD };
            domesticShipping1.ShippingServicePriority = 4;
            domesticShipping1.LocalPickup = true;
            domesticShipping1.FreeShipping = true;
            sd.ShippingServiceOptions = new ShippingServiceOptionsTypeCollection(new[] { domesticShipping1 });
            sd.ShippingType = ShippingTypeCodeType.Flat;
            return sd;
