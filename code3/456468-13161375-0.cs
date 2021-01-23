        PaymentDetailsType[] pmtDetails = new PaymentDetailsType[1];
        pmtDetails[0] = new PaymentDetailsType();
        var pmtIndex = 0;
        PaymentDetailsItemType[] items = new PaymentDetailsItemType[cartItems.Count];
        foreach (var item in cartItems)
        {
            var i = new PaymentDetailsItemType()
            {
                Name = item.productName,
                Number = item.productID.ToString(),
                Quantity = item.quantity.ToString(),
                Amount = new BasicAmountType(){ currencyID = CurrencyCodeType.GBP, Value = item.productPrice.ToString() }
            };
            items[pmtIndex] = i;
            pmtIndex++;
        }
        //reqDetails.p
        //reqDetails.PaymentDetails = pmtDetails;
        //hOrderTotal.Value
        // 
        pmtDetails[0].PaymentDetailsItem = items;
        pmtDetails[0].OrderTotal = new BasicAmountType() { currencyID = CurrencyCodeType.GBP, Value = HttpContext.Current.Session["_OrderTotalLessShippingAmount"].ToString() };
        reqDetails.PaymentDetails = pmtDetails;
