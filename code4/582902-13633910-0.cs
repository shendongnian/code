    foreach (var lineItem in oForm.LineItems)
    { 
        cartDetails.AppendFormat("{0,10:0}", lineItem.Quantity);
        cartDetails.AppendFormat("{0,10:0.00}", lineItem.Price);
        // etc
    }
